﻿using System;
using System.Linq;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.Data.Contracts;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;
using static NWN.NWScript;

namespace Freescape.Game.Server.Service
{
    public class PlayerService: IPlayerService
    {
        private readonly INWScript _;
        private readonly IDataContext _db;
        private readonly IDeathService _death;

        public PlayerService(INWScript nw, IDataContext db, IDeathService death)
        {
            _ = nw;
            _db = db;
            _death = death;
        }

        public void InitializePlayer(NWPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (player.Object == null) throw new ArgumentNullException(nameof(player.Object));

            if (!player.IsPlayer) return;

            if (!player.IsInitialized)
            {
                player.DestroyAllInventoryItems();
                player.Initialize();
                
                _.CreateItemOnObject("open_rest_menu", player.Object);
                _.AssignCommand(player.Object, () => _.TakeGoldFromCreature(_.GetGold(player.Object), player.Object, 1));

                NWItem knife = NWItem.Wrap(_.CreateItemOnObject("survival_knife", player.Object));
                knife.Name = player.Name + "'s Survival Knife";
                knife.IsCursed = true;
                knife.MaxDurability = 5;
                knife.Durability = 5;

                NWItem hammer = NWItem.Wrap(_.CreateItemOnObject("basic_hammer", player.Object));
                hammer.Name = player.Name + "'s Hammer";
                hammer.IsCursed = true;
                hammer.MaxDurability = 5;
                hammer.Durability = 5;

                NWItem darts = NWItem.Wrap(_.CreateItemOnObject("nw_wthdt001", player.Object, 50)); // 50x Dart
                darts.Name = "Starting Darts";
                darts.IsCursed = true;

                NWItem book = NWItem.Wrap(_.CreateItemOnObject("player_guide", player.Object));
                book.Name = player.Name + "'s Player Guide";
                book.IsCursed = true;

                NWItem dyeKit = NWItem.Wrap(_.CreateItemOnObject("tk_omnidye", player.Object));
                dyeKit.IsCursed = true;

                NWItem shovel = NWItem.Wrap(_.CreateItemOnObject("basic_shovel", player.Object));
                shovel.Name = player.Name + "'s Shovel";
                shovel.IsCursed = true;

                // TODO: UPDATE

                //int numberOfFeats = NWNX_Creature.GetFeatCount(player.Object);
                //for (int currentFeat = numberOfFeats; currentFeat >= 0; currentFeat--)
                //{
                //    NWNX_Creature.RemoveFeat(player.Object, NWNX_Creature.GetFeatByIndex(player.Object, currentFeat - 1));
                //}

                //NWNX_Creature.SetClassByPosition(player.Object, 0, Class.TYPE_FIGHTER);
                //NWNX_Creature.AddFeatByLevel(player.Object, Feat.ARMOR_PROFICIENCY_LIGHT, 1);
                //NWNX_Creature.AddFeatByLevel(player.Object, Feat.ARMOR_PROFICIENCY_MEDIUM, 1);
                //NWNX_Creature.AddFeatByLevel(player.Object, Feat.ARMOR_PROFICIENCY_HEAVY, 1);
                //NWNX_Creature.AddFeatByLevel(player.Object, Feat.SHIELD_PROFICIENCY, 1);
                //NWNX_Creature.AddFeatByLevel(player.Object, Feat.WEAPON_PROFICIENCY_EXOTIC, 1);
                //NWNX_Creature.AddFeatByLevel(player.Object, Feat.WEAPON_PROFICIENCY_MARTIAL, 1);
                //NWNX_Creature.AddFeatByLevel(player.Object, Feat.WEAPON_PROFICIENCY_SIMPLE, 1);

                //for (int iCurSkill = 1; iCurSkill <= 27; iCurSkill++)
                //{
                //    NWNX_Creature.SetSkillRank(player.Object, iCurSkill - 1, 0);
                //}
                //setFortitudeSavingThrow(player.Object, 0);
                //setReflexSavingThrow(player.Object, 0);
                //setWillSavingThrow(player.Object, 0);

                //int classID = getClassByPosition(1, player.Object);

                //for (int index = 0; index <= 255; index++)
                //{
                //    NWNX_Creature.RemoveKnownSpell(player.Object, classID, 0, index);
                //}

                using (DataContext context = new DataContext())
                {
                    PlayerCharacter entity = player.ToEntity();
                    context.PlayerCharacters.Add(entity);
                    context.SaveChanges();
                }
                

                // TODO: UPDATE
                //SkillSystem.ApplyStatChanges(player.Object, null);

                _.DelayCommand(1000, () => _.ApplyEffectToObject(DURATION_TYPE_INSTANT, _.EffectHeal(999), player.Object));

                InitializeHotBar(player);
            }

        }

        public PlayerCharacter GetPlayerEntity(NWPlayer player)
        {
            if(player == null) throw new ArgumentNullException(nameof(player));
            if(!player.IsPlayer) throw new ArgumentException(nameof(player) + " must be a player.", nameof(player));

            return _db.PlayerCharacters.Single(x => x.PlayerID == player.GlobalID);
        }

        public PlayerCharacter GetPlayerEntity(string playerID)
        {
            if (string.IsNullOrWhiteSpace(playerID)) throw new ArgumentException("Invalid player ID.", nameof(playerID));

            return _db.PlayerCharacters.Single(x => x.PlayerID == playerID);
        }

        public void OnAreaEnter()
        {
            NWPlayer player = NWPlayer.Wrap(_.GetEnteringObject());

            LoadLocation(player);
            SaveLocation(player);
            ApplySanctuaryEffects(player);
            AdjustCamera(player);
            if(player.IsPlayer)
                _.ExportSingleCharacter(player.Object);
        }

        public void SaveLocation(NWPlayer player)
        {
            if (!player.IsPlayer) return;

            NWArea area = player.Area;
            bool isPlayerHome = area.GetLocalInt("IS_PLAYER_HOME") == 1;

            if (area.Tag != "ooc_area" && !isPlayerHome)
            {
                PlayerCharacter entity = GetPlayerEntity(player.GlobalID);
                entity.LocationAreaTag = area.Tag;
                entity.LocationX = player.Position.m_X;
                entity.LocationY = player.Position.m_Y;
                entity.LocationZ = player.Position.m_Z;
                entity.LocationOrientation = (player.Facing);

                _db.SaveChanges();

                if (entity.RespawnAreaTag == "")
                {
                    _death.BindPlayerSoul(player, false);
                }
            }
        }

        private void LoadLocation(NWPlayer player)
        {
            if (!player.IsPlayer) return;

            if (player.Area.Tag != "ooc_area")
            {
                PlayerCharacter entity = GetPlayerEntity(player.GlobalID);
                NWArea area = NWArea.Wrap(_.GetObjectByTag(entity.LocationAreaTag));
                Vector position = _.Vector((float)entity.LocationX, (float)entity.LocationY, (float)entity.LocationZ);
                Location location = _.Location(area.Object,
                    position,
                    (float)entity.LocationOrientation);

                player.AssignCommand(() => _.ActionJumpToLocation(location));
            }
        }


        private void CheckForMovement(NWPlayer oPC, Location location)
        {
            if (!oPC.IsValid || oPC.IsDead) return;
            
            string areaResref = oPC.Area.Resref;
            Vector position = _.GetPositionFromLocation(location);

            if (areaResref != _.GetResRef(_.GetAreaFromLocation(location)) ||
                oPC.Facing != _.GetFacingFromLocation(location) ||
                oPC.Position.m_X != position.m_X ||
                oPC.Position.m_Y != position.m_Y ||
                oPC.Position.m_Z != position.m_Z)
            {
                foreach (Effect effect in oPC.Effects)
                {
                    int type = _.GetEffectType(effect);
                    if (type == EFFECT_TYPE_DAMAGE_REDUCTION || type == EFFECT_TYPE_SANCTUARY)
                    {
                        _.RemoveEffect(oPC.Object, effect);
                    }
                }
                return;
            }
            
            oPC.AssignCommand(() =>
            {
                CheckForMovement(oPC, location);
            }, 1.0f);
        }

        private void ApplySanctuaryEffects(NWPlayer oPC)
        {
            if (!oPC.IsPlayer) return;
            if (oPC.CurrentHP <= 0) return;
            if (oPC.Area.Tag == "ooc_area") return;

            Effect sanctuary = _.EffectSanctuary(99);
            Effect dr = _.EffectDamageReduction(50, DAMAGE_POWER_PLUS_TWENTY);
            sanctuary = _.TagEffect(sanctuary, "AREA_ENTRY_SANCTUARY");
            dr = _.TagEffect(dr, "AREA_ENTRY_DAMAGE_REDUCTION");

            _.ApplyEffectToObject(DURATION_TYPE_PERMANENT, sanctuary, oPC.Object);
            _.ApplyEffectToObject(DURATION_TYPE_PERMANENT, dr, oPC.Object);
            Location location = oPC.Location;

            oPC.AssignCommand(() =>
            {
                CheckForMovement(oPC, location);
            }, 3.5f);
        }
        
        private void AdjustCamera(NWPlayer oPC)
        {
            if (!oPC.IsPlayer) return;

            float facing = oPC.Facing - 180;
            _.SetCameraFacing(facing, 1.0f, 1.0f);
        }


        private void InitializeHotBar(NWPlayer player)
        {

        }

    }
}