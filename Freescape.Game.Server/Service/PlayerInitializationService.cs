using Freescape.Game.Server.Data;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;

namespace Freescape.Game.Server.Service
{
    public class PlayerInitializationService: IPlayerInitializationService
    {
        private readonly INWScript _;

        public PlayerInitializationService(INWScript nw)
        {
            _ = nw;
        }

        public void InitializePlayer(NWPlayer player)
        {
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

                _.DelayCommand(1000, () => _.ApplyEffectToObject(NWScript.DURATION_TYPE_INSTANT, _.EffectHeal(999), player.Object));

                InitializeHotBar(player);
            }

        }

        private void InitializeHotBar(NWPlayer player)
        {
            
        }

    }
}
