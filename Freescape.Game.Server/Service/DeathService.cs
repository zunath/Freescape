using System;
using System.Collections.Generic;
using System.Linq;
using Freescape.Game.Server.Data.Contracts;
using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.NWNX.Contracts;
using Freescape.Game.Server.Service.Contracts;
using NWN;
using static NWN.NWScript;

namespace Freescape.Game.Server.Service
{
    public class DeathService : IDeathService
    {
        private readonly IDataContext _db;
        private readonly INWScript _;
        private readonly ISCORCO _scorco;

        public DeathService(IDataContext db, 
            INWScript script,
            ISCORCO scorco)
        {
            _db = db;
            _ = script;
            _scorco = scorco;
        }


        // Resref and tag of the player corpse placeable
        private const string CorpsePlaceableResref = "pc_corpse";

        // Message which displays on the Respawn pop up menu
        private const string RespawnMessage = "You have died. You can wait for another player to revive you or give up and permanently go to the death realm.";


        public void OnModuleLoad()
        {
            List<PCCorpse> entities = _db.PCCorpses.ToList();

            foreach (PCCorpse entity in entities)
            {
                NWArea area = NWArea.Wrap(_.GetObjectByTag(entity.AreaTag));
                Vector position = new Vector((float)entity.PositionX, (float)entity.PositionY, (float)entity.PositionZ);
                Location location = _.Location(area.Object, position, (float)entity.Orientation);
                NWPlaceable corpse = NWPlaceable.Wrap(_.CreateObject(OBJECT_TYPE_PLACEABLE, CorpsePlaceableResref, location));
                corpse.Name = entity.Name;
                corpse.IdentifiedDescription = entity.Name;
                corpse.SetLocalInt("CORPSE_ID", (int)entity.PCCorpseID);

                foreach (PCCorpseItem item in entity.PCCorpseItems)
                {
                    _scorco.LoadObject(item.NWItemObject, location, corpse.Object);
                }
            }
        }

        public void OnPlayerDeath()
        {
            NWPlayer oPC = NWPlayer.Wrap(_.GetLastPlayerDied());
            string corpseName = oPC.Name + "'s Corpse";
            NWObject oHostileActor = NWObject.Wrap(_.GetLastHostileActor(oPC.Object));
            Location location = oPC.Location;
            bool hasItems = false;

            var factionMember = _.GetFirstFactionMember(oHostileActor.Object, FALSE);
            while(_.GetIsObjectValid(factionMember) == TRUE)
            {
                _.ClearPersonalReputation(oPC.Object, factionMember);
            }

            _.PopUpDeathGUIPanel(oPC.Object, TRUE, TRUE, 0, RespawnMessage);

            NWPlaceable corpse = NWPlaceable.Wrap(_.CreateObject(OBJECT_TYPE_PLACEABLE, CorpsePlaceableResref, location));
            PCCorpse entity = new PCCorpse
            {
                AreaTag = _.GetTag(_.GetAreaFromLocation(location)),
                Name = corpseName,
                Orientation = _.GetFacingFromLocation(location),
                PositionX = _.GetPositionFromLocation(location).m_X,
                PositionY = _.GetPositionFromLocation(location).m_Y,
                PositionZ = _.GetPositionFromLocation(location).m_Z
            };

            if (oPC.Gold > 0)
            {
                corpse.AssignCommand(() =>
                {
                    _.TakeGoldFromCreature(oPC.Gold, oPC.Object);
                });

                hasItems = true;
            }

            foreach (NWItem item in oPC.InventoryItems)
            {
                if (!item.IsCursed)
                {
                    _.CopyItem(item.Object, corpse.Object, TRUE);
                    item.Destroy();
                    hasItems = true;
                }
            }

            if (!hasItems)
            {
                corpse.Destroy();
                return;
            }

            corpse.Name = corpseName;
            corpse.IdentifiedDescription = corpseName;

            foreach (NWItem corpseItem in corpse.InventoryItems)
            {
                PCCorpseItem corpseItemEntity = new PCCorpseItem();
                byte[] data = _scorco.SaveObject(corpseItem.Object);
                corpseItemEntity.NWItemObject = data;
                corpseItemEntity.PCCorpseItemID = entity.PCCorpseID;
                entity.PCCorpseItems.Add(corpseItemEntity);
            }

            _db.PCCorpses.Add(entity);
            _db.SaveChanges();
            corpse.SetLocalInt("CORPSE_ID", (int)entity.PCCorpseID);
        }

        public void OnPlayerRespawn()
        {
            NWPlayer oPC = NWPlayer.Wrap(_.GetLastRespawnButtonPresser());

            int amount = oPC.MaxHP / 2;
            _.ApplyEffectToObject(DURATION_TYPE_INSTANT, _.EffectResurrection(), oPC.Object);
            _.ApplyEffectToObject(DURATION_TYPE_INSTANT, _.EffectHeal(amount), oPC.Object);

            TeleportPlayerToBindPoint(oPC);
        }

        public void OnCorpseDisturb(NWPlaceable corpse)
        {
            NWPlayer oPC = NWPlayer.Wrap(_.GetLastDisturbed());

            if (!oPC.IsPlayer && !oPC.IsDM) return;

            int corpseID = corpse.GetLocalInt("CORPSE_ID");
            NWItem oItem = NWItem.Wrap(_.GetInventoryDisturbItem());
            int disturbType = _.GetInventoryDisturbType();

            if (disturbType == INVENTORY_DISTURB_TYPE_ADDED)
            {
                _.ActionGiveItem(oItem.Object, oPC.Object);
                oPC.FloatingText("You cannot put items into corpses.");
            }
            else
            {
                PCCorpse entity = _db.PCCorpses.Single(x => x.PCCorpseID == corpseID);
                entity.PCCorpseItems.Clear();
                
                foreach (NWItem corpseItem in corpse.InventoryItems)
                {
                    PCCorpseItem corpseItemEntity = new PCCorpseItem();
                    byte[] data = _scorco.SaveObject(corpseItem.Object);
                    corpseItemEntity.NWItemObject = data;
                    corpseItemEntity.PCCorpseID = entity.PCCorpseID;
                    entity.PCCorpseItems.Add(corpseItemEntity);
                }

                _db.SaveChanges();
            }
        }

        public void OnCorpseClose(NWPlaceable corpse)
        {
            var items = corpse.InventoryItems;
            if (items.Count <= 0)
            {
                int corpseID = corpse.GetLocalInt("CORPSE_ID");
                PCCorpse entity = _db.PCCorpses.Single(x => x.PCCorpseID == corpseID);
                _db.PCCorpses.Remove(entity);
                _db.SaveChanges();
                corpse.Destroy();
            }
        }


        public void BindPlayerSoul(NWPlayer player, bool showMessage)
        {
            if (player == null) throw new ArgumentNullException(nameof(player), nameof(player) + " cannot be null.");
            if (player.Object == null) throw new ArgumentNullException(nameof(player.Object), nameof(player.Object) + " cannot be null.");

            PlayerCharacter pc = _db.PlayerCharacters.Single(x => x.PlayerID == player.GlobalID);
            pc.RespawnLocationX = player.Position.m_X;
            pc.RespawnLocationY = player.Position.m_Y;
            pc.RespawnLocationZ = player.Position.m_Z;
            pc.RespawnLocationOrientation = player.Facing;
            pc.RespawnAreaTag = player.Area.Tag;

            _db.SaveChanges();

            if (showMessage)
            {
                _.FloatingTextStringOnCreature("Your soul has been bound to this location.", player.Object, FALSE);
            }
        }


        public void TeleportPlayerToBindPoint(NWPlayer pc)
        {
            PlayerCharacter entity = _db.PlayerCharacters.Single(x => x.PlayerID == pc.GlobalID);
            TeleportPlayerToBindPoint(pc, entity);
        }

        private void TeleportPlayerToBindPoint(NWObject pc, PlayerCharacter entity)
        {
            if (entity.CurrentHunger < 50)
                entity.CurrentHunger = 50;

            if (string.IsNullOrWhiteSpace(entity.RespawnAreaTag))
            {
                NWObject defaultRespawn = NWObject.Wrap(_.GetWaypointByTag("DEFAULT_RESPAWN_POINT"));
                Location location = defaultRespawn.Location;

                pc.AssignCommand(() =>
                {
                    _.ActionJumpToLocation(location);
                });
            }
            else
            {
                pc.AssignCommand(() =>
                {
                    NWArea area = NWArea.Wrap(_.GetObjectByTag(entity.RespawnAreaTag));
                    Vector position = _.Vector((float)entity.RespawnLocationX, (float)entity.RespawnLocationY, (float)entity.RespawnLocationZ);
                    Location location = _.Location(area.Object, position, (float)entity.RespawnLocationOrientation);
                    _.ActionJumpToLocation(location);
                });
            }
        }
    }
}
