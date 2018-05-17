using System.Collections.Generic;
using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface ICraftService
    {
        List<CraftBlueprintCategory> GetCategoriesAvailableToPCByDeviceID(string playerID, int deviceID);
        List<CraftBlueprint> GetPCBlueprintsByDeviceAndCategoryID(string playerID, int deviceID, int categoryID);
        string BuildBlueprintHeader(NWPlayer player, int blueprintID);
        CraftBlueprint GetBlueprintByID(int craftBlueprintID);
        List<CraftBlueprintCategory> GetCategoriesAvailableToPC(string playerID);
        List<CraftBlueprint> GetPCBlueprintsByCategoryID(string playerID, int categoryID);
    }
}
