using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface ISkillService
    {
        int SkillCap { get; }
        void ApplyStatChanges(NWPlayer player, NWItem ignoreItem);
        void RegisterPCToAllCombatTargetsForSkill(NWPlayer player, SkillType skillType);
        void GiveSkillXP(NWPlayer player, SkillType skill, int amount);
    }
}
