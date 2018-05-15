using System.Collections.Generic;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.Data.Contracts;
using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class SkillService: ISkillService
    {
        private readonly IDataContext _db;

        public SkillService(IDataContext db)
        {
            _db = db;
        }

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

        public void GiveSkillXP(NWPlayer player, int skillID, int amount)
        {
        }

        public PCSkill GetPCSkill(NWPlayer player, SkillType skill)
        {
            return null;
        }

        public int GetPCTotalSkillCount(string playerID)
        {
            return 0;
        }

        public PCSkill GetPCSkillByID(string playerID, int skillID)
        {
            return null;
        }

        public List<SkillCategory> GetActiveCategories()
        {
            return null;
        }

        public List<PCSkill> GetPCSkillsForCategory(string playerID, int skillCategoryID)
        {
            return null;
        }

        public SkillXPRequirement GetSkillXPRequirementByRank(int skillID, int rank)
        {
            return null;
        }

        public void ToggleSkillLock(string playerID, int skillID)
        {
            PCSkill pcSkill = GetPCSkillByID(playerID, skillID);
            pcSkill.IsLocked = !pcSkill.IsLocked;

            _db.SaveChanges();
        }

        public void OnCreatureDeath(NWCreature creature)
        {
        }

        public void OnAreaExit()
        {
        }
    }
}
