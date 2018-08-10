using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface ICustomEffectService
    {
        int GetActiveEffectLevel(NWObject target, CustomEffectType effectType);
        void ApplyCustomEffect(NWCreature caster, NWCreature target, CustomEffectType effectType, int ticks, int level);
        int CalculateEffectAC(NWCreature creature);
    }
}
