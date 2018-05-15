using System.Collections.Generic;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.ValueObject.Perk;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IPerkService
    {
        int GetPCPerkLevel(NWPlayer player, PerkType perkType);
        int GetPCTotalPerkCount(string playerID);
        List<PCPerkHeader> GetPCPerksForMenuHeader(string playerID);
        List<PerkCategory> GetPerkCategoriesForPC(string playerID);
        List<Data.Perk> GetPerksForPC(string playerID, int categoryID);
        Data.Perk GetPerkByID(int perkID);
        PCPerk GetPCPerkByID(string playerID, int perkID);
        PerkLevel FindPerkLevel(IEnumerable<PerkLevel> levels, int findLevel);
        bool CanPerkBeUpgraded(Data.Perk perk, PCPerk pcPerk, PlayerCharacter player);
        void DoPerkUpgrade(NWPlayer player, int perkID);
    }
}
