using System.Collections.Generic;
using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class KeyItemService: IKeyItemService
    {
        public IEnumerable<PCKeyItem> GetPlayerKeyItemsByCategory(NWPlayer player, int categoryID)
        {
            yield break;
        }

        public KeyItem GetKeyItemByID(int keyItemID)
        {
            return null;
        }

        public void OnModuleItemAcquired()
        {
        }
    }
}
