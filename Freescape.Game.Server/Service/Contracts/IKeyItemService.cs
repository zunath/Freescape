using System.Collections.Generic;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IKeyItemService
    {
        IEnumerable<PCKeyItem> GetPlayerKeyItemsByCategory(NWPlayer player, int categoryID);
        KeyItem GetKeyItemByID(int keyItemID);
        void OnModuleItemAcquired();
    }
}
