using System.Collections.Generic;
using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using Freescape.Game.Server.ValueObject.Perk;

namespace Freescape.Game.Server.Service
{
    public class PerkService: IPerkService
    {
        public int GetPCPerkLevel(NWPlayer player, PerkType perkType)
        {
            return 0;
        }

        public int GetPCTotalPerkCount(string playerID)
        {
            return 0;
        }

        public List<PCPerkHeader> GetPCPerksForMenuHeader(string playerID)
        {
            return null;
        }

        public List<PerkCategory> GetPerkCategoriesForPC(string playerID)
        {
            return null;
        }

        public List<Data.Entities.Perk> GetPerksForPC(string playerID, int categoryID)
        {
            return null;
        }

        public Data.Entities.Perk GetPerkByID(int perkID)
        {
            return null;
        }

        public PCPerk GetPCPerkByID(string playerID, int perkID)
        {
            return null;
        }

        public PerkLevel FindPerkLevel(IEnumerable<PerkLevel> levels, int findLevel)
        {
            return null;
        }

        public bool CanPerkBeUpgraded(Data.Entities.Perk perk, PCPerk pcPerk, PlayerCharacter player)
        {
            return false;
        }

        public void DoPerkUpgrade(NWPlayer player, int perkID)
        {
        }

        public string OnModuleExamine(string existingDescription, NWPlayer examiner, NWObject examinedObject)
        {
            return null;
        }
    }
}
