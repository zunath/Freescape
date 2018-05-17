using System.Collections.Generic;
using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class CraftService: ICraftService
    {
        public List<CraftBlueprintCategory> GetCategoriesAvailableToPCByDeviceID(string playerID, int deviceID)
        {
            return null;
        }

        public List<CraftBlueprint> GetPCBlueprintsByDeviceAndCategoryID(string playerID, int deviceID, int categoryID)
        {
            return null;
        }

        public string BuildBlueprintHeader(NWPlayer player, int blueprintID)
        {
            return null;
        }

        public CraftBlueprint GetBlueprintByID(int craftBlueprintID)
        {
            return null;
        }

        public List<CraftBlueprintCategory> GetCategoriesAvailableToPC(string playerID)
        {
            return null;
        }

        public List<CraftBlueprint> GetPCBlueprintsByCategoryID(string playerID, int categoryID)
        {
            return null;
        }
    }
}
