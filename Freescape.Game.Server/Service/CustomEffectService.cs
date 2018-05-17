using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class CustomEffectService: ICustomEffectService
    {
        public int GetActiveEffectLevel(NWObject target, CustomEffectType effectType)
        {
            return 0;
        }

        public void ApplyCustomEffect(NWCreature caster, NWCreature target, CustomEffectType effectType, int ticks, int level)
        {
        }
    }
}
