using System;
using System.Collections.Generic;
using System.Linq;
using Freescape.Game.Server.CustomEffect.Contracts;
using Freescape.Game.Server.Data.Contracts;
using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;
using static NWN.NWScript;

namespace Freescape.Game.Server.Service
{
    public class CustomEffectService : ICustomEffectService
    {
        private class CasterSpell
        {
            public NWCreature Caster { get; set; }
            public NWObject Target { get; set; }
            public string EffectName { get; set; }
            public int CustomEffectID { get; set; }
        }

        private readonly Dictionary<CasterSpell, int> _npcEffectList;
        private readonly List<CasterSpell> _effectsToRemove;

        private readonly IDataContext _db;
        private readonly IErrorService _error;
        private readonly INWScript _;

        public CustomEffectService(IDataContext db,
            IErrorService error,
            INWScript script)
        {
            _npcEffectList = new Dictionary<CasterSpell, int>();
            _effectsToRemove = new List<CasterSpell>();
            _db = db;
            _error = error;
            _ = script;
        }

        public int GetActiveEffectLevel(NWObject target, CustomEffectType effectType)
        {
            return GetActiveEffectLevel(target, (int)effectType);
        }

        public void ApplyCustomEffect(NWCreature caster, NWCreature target, CustomEffectType effectType, int ticks, int level)
        {
            ApplyCustomEffect(caster, target, (int) effectType, ticks, level);
        }

        public int CalculateEffectAC(NWCreature creature)
        {
            int effectLevel = GetActiveEffectLevel(creature, CustomEffectType.Aegis);
            int aegisAC = 0;

            if (effectLevel > 0)
            {
                switch (effectLevel)
                {
                    case 1:
                        aegisAC = 1;
                        break;
                    case 2:
                    case 3:
                        aegisAC = 2;
                        break;
                    case 4:
                        aegisAC = 3;
                        break;
                    case 5:
                        aegisAC = 4;
                        break;
                    default: return 0;
                }
            }

            return aegisAC;
        }

        public void OnPlayerHeartbeat(NWPlayer oPC)
        {
            List<PCCustomEffect> effects = _db.PCCustomEffects.Where(x => x.PlayerID == oPC.GlobalID).ToList();
            string areaResref = oPC.Area.Resref;

            foreach (PCCustomEffect effect in effects)
            {
                if (oPC.CurrentHP <= -11 || areaResref == "death_realm")
                {
                    RemovePCCustomEffect(oPC, effect.CustomEffectID);
                    return;
                }

                PCCustomEffect result = RunPCCustomEffectProcess(oPC, effect);
                if (result == null)
                {
                    oPC.SendMessage(effect.CustomEffect.WornOffMessage);
                    ICustomEffect handler = App.Resolve<ICustomEffect>(effect.CustomEffect.ScriptHandler);
                    handler?.WearOff(null, oPC);

                    oPC.DeleteLocalInt("CUSTOM_EFFECT_ACTIVE_" + effect.CustomEffectID);
                    _db.PCCustomEffects.Remove(effect);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
            }
        }


        public void OnModuleHeartbeat()
        {
            foreach (var entry in _npcEffectList)
            {
                CasterSpell casterModel = entry.Key;
                _npcEffectList[entry.Key] = entry.Value - 1;
                Data.Entities.CustomEffect entity = _db.CustomEffects.Single(x => x.CustomEffectID == casterModel.CustomEffectID);
                ICustomEffect handler = App.Resolve<ICustomEffect>(entity.ScriptHandler);

                try
                {
                    handler?.Tick(casterModel.Caster, casterModel.Target);
                }
                catch (Exception ex)
                {
                    _error.LogError(ex, "OnModuleHeartbeat was unable to run specific effect script: " + entity.ScriptHandler);
                }


                // Kill the effect if it has expired, target is invalid, or target is dead.
                if (entry.Value <= 0 ||
                        !casterModel.Target.IsValid ||
                        casterModel.Target.CurrentHP <= -11)
                {
                    _effectsToRemove.Add(entry.Key);

                    handler?.WearOff(casterModel.Caster, casterModel.Target);

                    if (casterModel.Caster.IsValid && casterModel.Caster.IsPlayer)
                    {
                        casterModel.Caster.SendMessage("Your effect '" + casterModel.EffectName + "' has worn off of " + casterModel.Target.Name);
                    }

                    casterModel.Target.DeleteLocalInt("CUSTOM_EFFECT_ACTIVE_" + casterModel.CustomEffectID);
                }
            }

            foreach (CasterSpell entry in _effectsToRemove)
            {
                _npcEffectList.Remove(entry);
            }
            _effectsToRemove.Clear();
        }

        private PCCustomEffect RunPCCustomEffectProcess(NWPlayer oPC, PCCustomEffect effect)
        {
            effect.Ticks = effect.Ticks - 1;
            if (effect.Ticks < 0) return null;

            if (!string.IsNullOrWhiteSpace(effect.CustomEffect.ContinueMessage))
            {
                oPC.SendMessage(effect.CustomEffect.ContinueMessage);
            }

            ICustomEffect handler = App.Resolve<ICustomEffect>(effect.CustomEffect.ScriptHandler);

            handler?.Tick(null, oPC);

            return effect;
        }

        public void ApplyCustomEffect(NWCreature oCaster, NWCreature oTarget, int customEffectID, int ticks, int effectLevel)
        {
            // Can't apply the effect if the existing one is stronger.
            int existingEffectLevel = GetActiveEffectLevel(oTarget, customEffectID);
            if (existingEffectLevel > effectLevel)
            {
                oCaster.SendMessage("A more powerful effect already exists on your target.");
                return;
            }

            // No custom effects can be applied if player is under the effect of sanctuary.
            foreach (Effect effect in oTarget.Effects)
            {
                int type = _.GetEffectType(effect);
                if (type == EFFECT_TYPE_SANCTUARY) return;
            }

            Data.Entities.CustomEffect effectEntity = _db.CustomEffects.Single(x => x.CustomEffectID == customEffectID);

            // PC custom effects are tracked in the database.
            if (oTarget.IsPlayer)
            {
                PCCustomEffect entity = _db.PCCustomEffects.Single(x => x.PlayerID == oTarget.GlobalID && x.CustomEffectID == customEffectID);

                if (entity == null)
                {
                    entity = new PCCustomEffect();
                    entity.PlayerID = oTarget.GlobalID;
                    entity.CustomEffectID = effectEntity.CustomEffectID;
                }

                entity.Ticks = ticks;
                _db.SaveChanges();

                oTarget.SendMessage(effectEntity.StartMessage);
            }
            // NPCs custom effects are tracked in server memory.
            else
            {
                // Look for existing effect.
                foreach (var entry in _npcEffectList)
                {
                    CasterSpell casterSpellModel = entry.Key;

                    if (casterSpellModel.Caster == oCaster &&
                       casterSpellModel.CustomEffectID == customEffectID &&
                       casterSpellModel.Target == oTarget)
                    {
                        _npcEffectList[entry.Key] = ticks;
                        return;
                    }
                }

                // Didn't find an existing effect. Create a new one.
                CasterSpell spellModel = new CasterSpell();
                spellModel.Caster = oCaster;
                spellModel.CustomEffectID = customEffectID;
                spellModel.EffectName = effectEntity.Name;
                spellModel.Target = oTarget;

                _npcEffectList[spellModel] = ticks;
            }

            ICustomEffect handler = App.Resolve<ICustomEffect>(effectEntity.ScriptHandler);
            handler?.Apply(oCaster, oTarget);
            oTarget.SetLocalInt("CUSTOM_EFFECT_ACTIVE_" + customEffectID, effectLevel);
        }

        public bool DoesPCHaveCustomEffect(NWPlayer oPC, int customEffectID)
        {
            PCCustomEffect effect = _db.PCCustomEffects.Single(x => x.PlayerID == oPC.GlobalID && x.CustomEffectID == customEffectID);

            return effect != null;
        }

        public bool DoesPCHaveCustomEffect(NWPlayer oPC, CustomEffectType customEffectType)
        {
            return DoesPCHaveCustomEffect(oPC, (int) customEffectType);
        }

        public void RemovePCCustomEffect(NWPlayer oPC, long customEffectID)
        {
            PCCustomEffect effect = _db.PCCustomEffects.Single(x => x.PlayerID == oPC.GlobalID && x.CustomEffectID == customEffectID);
            oPC.DeleteLocalInt("CUSTOM_EFFECT_ACTIVE_" + customEffectID);

            if (effect == null) return;

            _db.PCCustomEffects.Remove(effect);
            oPC.SendMessage(effect.CustomEffect.WornOffMessage);
        }

        public void RemovePCCustomEffect(NWPlayer oPC, CustomEffectType customEffectType)
        {
            RemovePCCustomEffect(oPC, (long) customEffectType);
        }

        public int GetActiveEffectLevel(NWObject oTarget, int customEffectID)
        {
            string varName = "CUSTOM_EFFECT_ACTIVE_" + customEffectID;
            return oTarget.GetLocalInt(varName);
        }


    }
}
