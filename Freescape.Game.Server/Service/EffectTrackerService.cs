using System.Collections.Generic;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;
using static NWN.NWScript;

namespace Freescape.Game.Server.Service
{
    public class EffectTrackerService : IEffectTrackerService
    {
        private static Dictionary<string, int> _effectTicks;

        private readonly INWScript _;

        public EffectTrackerService(INWScript script)
        {
            _effectTicks = new Dictionary<string, int>();
            _ = script;
        }

        public void ProcessPCEffects(NWPlayer oPC)
        {
            HashSet<string> foundIDs = new HashSet<string>();

            foreach (Effect effect in oPC.Effects)
            {
                string pcUUID = oPC.GlobalID;
                string effectKey = pcUUID + "_" + _.GetEffectType(effect);

                if (_.GetEffectDurationType(effect) != DURATION_TYPE_PERMANENT) continue;
                if (!string.IsNullOrWhiteSpace(_.GetEffectTag(effect))) continue;

                int ticks = _effectTicks.ContainsKey(effectKey) ? _effectTicks[effectKey] : 40;
                ticks--;

                if (ticks <= 0)
                {
                    _.RemoveEffect(oPC.Object, effect);
                    _effectTicks.Remove(effectKey);
                }
                else
                {
                    foundIDs.Add(effectKey);
                    _effectTicks[effectKey] = ticks;
                }
            }

            foreach (var effect in _effectTicks)
            {
                if (!foundIDs.Contains(effect.Key))
                {
                    _effectTicks.Remove(effect.Key);
                }
            }
        }
}
}
