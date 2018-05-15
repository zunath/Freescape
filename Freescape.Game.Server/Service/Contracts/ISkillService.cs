using System.Collections.Generic;
using Freescape.Game.Server.Data;
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
        void GiveSkillXP(NWPlayer player, int skillID, int amount);
        PCSkill GetPCSkill(NWPlayer player, SkillType skill);
        int GetPCTotalSkillCount(string playerID);
        PCSkill GetPCSkillByID(string playerID, int skillID);
        List<SkillCategory> GetActiveCategories();
        List<PCSkill> GetPCSkillsForCategory(string playerID, int skillCategoryID);
        SkillXPRequirement GetSkillXPRequirementByRank(int skillID, int rank);
        void ToggleSkillLock(string playerID, int skillID);
    }
}
