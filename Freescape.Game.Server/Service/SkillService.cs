using Freescape.Game.Server.Data;
using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class SkillService: ISkillService
    {
        public int SkillCap => 500;
        public void ApplyStatChanges(NWPlayer player, NWItem ignoreItem)
        {
        }

        public void RegisterPCToAllCombatTargetsForSkill(NWPlayer player, SkillType skillType)
        {
        }

        public void GiveSkillXP(NWPlayer player, SkillType skill, int amount)
        {
        }

        public PCSkill GetPCSkill(NWPlayer player, SkillType skill)
        {
            return null;
        }
    }
}
