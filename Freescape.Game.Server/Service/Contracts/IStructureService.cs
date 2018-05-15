using System.Collections.Generic;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.ValueObject.Structure;
using NWN;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IStructureService
    {
        NWObject GetTerritoryFlagOwnerOfLocation(Location location);
        int GetTerritoryFlagID(NWObject flag);
        int GetPlaceableStructureID(NWPlaceable structure);
        PCTerritoryFlag GetPCTerritoryFlagByBuildingStructureID(int buildingStructureID);
        bool PlayerHasPermission(NWPlayer player, StructurePermission permission, int territoryFlagID);
        BuildingOwners GetBuildingOwners(int territoryFlagID, int structureID);
        PCTerritoryFlagsStructure GetPCStructureByID(int structureID);
        void CreateConstructionSiteFromEntity(ConstructionSite site);
        void CreateStructureFromEntity(PCTerritoryFlagsStructure entity);
        void JumpPCToBuildingInterior(NWPlayer player, NWArea instance);
        int CanPCBuildInLocation(NWPlayer player, Location targetLocation, StructurePermission permission);
        void CreateConstructionSite(NWPlayer player, Location location);
        void SetIsPCMovingStructure(NWPlayer player, NWPlaceable structure, bool isMoving);
        NWPlaceable CreateBuildingDoor(Location houseLocation, int structureID);
        bool IsConstructionSiteValid(NWPlaceable placeable);
        PCTerritoryFlag GetPCTerritoryFlagByID(int territoryFlagID);
        int GetConstructionSiteID(NWPlaceable site);
        ConstructionSite GetConstructionSiteByID(int constructionSiteID);
        string BuildMenuHeader(int blueprintID);
        List<StructureCategory> GetStructureCategoriesByType(string playerID, bool isTerritoryFlagCategory, bool isVanity, bool isSpecial, bool isResource, bool isBuilding);
        TerritoryStructureCount GetNumberOfStructuresInTerritory(int flagID);
        List<StructureBlueprint> GetStructuresByCategoryAndType(string playerID, int structureCategoryID, bool isVanity, bool isSpecial, bool isResource, bool isBuilding);
        bool WillBlueprintOverlapWithExistingFlags(Location location, int blueprintID);
        StructureBlueprint GetStructureBlueprintByID(int blueprintID);
        void RazeConstructionSite(NWPlayer player, NWPlaceable structure, bool recoverMaterials);
        NWPlaceable CompleteStructure(NWPlaceable site);
        void LogQuickBuildAction(NWPlayer dm, NWPlaceable completedStructure);
        void SelectBlueprint(NWPlayer player, NWPlaceable site, int blueprintID);
        List<BuildingInterior> GetBuildingInteriorsByCategoryID(int buildingCategoryID);
        void PreviewBuildingInterior(NWPlayer player, int buildingInteriorID);
        void SetStructureCustomName(NWPlayer player, NWPlaceable structure, string customName);

        void SaveChanges();
    }
}
