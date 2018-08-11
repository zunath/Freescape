using System.Collections.Generic;
using Freescape.Game.Server.Data.Contracts;
using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using Freescape.Game.Server.ValueObject.Structure;
using NWN;

namespace Freescape.Game.Server.Service
{
    public class StructureService: IStructureService
    {
        private readonly IDataContext _db;

        public StructureService(IDataContext db)
        {
            _db = db;
        }

        public void OnModuleLoad()
        {
            
        }

        public NWObject GetTerritoryFlagOwnerOfLocation(Location location)
        {
            return null;
        }

        public int GetTerritoryFlagID(NWObject flag)
        {
            return 0;
        }

        public int GetPlaceableStructureID(NWPlaceable structure)
        {
            return 0;
        }

        public PCTerritoryFlag GetPCTerritoryFlagByBuildingStructureID(int buildingStructureID)
        {
            return null;
        }

        public bool PlayerHasPermission(NWPlayer player, StructurePermission permission, int territoryFlagID)
        {
            return false;
        }

        public BuildingOwners GetBuildingOwners(int territoryFlagID, int structureID)
        {
            return null;
        }

        public PCTerritoryFlagsStructure GetPCStructureByID(int structureID)
        {
            return null;
        }

        public void CreateConstructionSiteFromEntity(ConstructionSite site)
        {
        }

        public void CreateStructureFromEntity(PCTerritoryFlagsStructure entity)
        {
        }

        public void JumpPCToBuildingInterior(NWPlayer player, NWArea instance)
        {
        }

        public int CanPCBuildInLocation(NWPlayer player, Location targetLocation, StructurePermission permission)
        {
            return 0;
        }

        public void CreateConstructionSite(NWPlayer player, Location location)
        {
        }

        public void SetIsPCMovingStructure(NWPlayer player, NWPlaceable structure, bool isMoving)
        {
        }

        public NWPlaceable CreateBuildingDoor(Location houseLocation, int structureID)
        {
            return null;
        }

        public bool IsConstructionSiteValid(NWPlaceable placeable)
        {
            return false;
        }

        public PCTerritoryFlag GetPCTerritoryFlagByID(int territoryFlagID)
        {
            return null;
        }

        public int GetConstructionSiteID(NWPlaceable site)
        {
            return 0;
        }

        public ConstructionSite GetConstructionSiteByID(int constructionSiteID)
        {
            return null;
        }

        public string BuildMenuHeader(int blueprintID)
        {
            return null;
        }

        public List<StructureCategory> GetStructureCategoriesByType(string playerID, bool isTerritoryFlagCategory, bool isVanity, bool isSpecial, bool isResource, bool isBuilding)
        {
            return null;
        }

        public TerritoryStructureCount GetNumberOfStructuresInTerritory(int flagID)
        {
            return null;
        }

        public List<StructureBlueprint> GetStructuresByCategoryAndType(string playerID, int structureCategoryID, bool isVanity, bool isSpecial, bool isResource, bool isBuilding)
        {
            return null;
        }

        public bool WillBlueprintOverlapWithExistingFlags(Location location, int blueprintID)
        {
            return false;
        }

        public StructureBlueprint GetStructureBlueprintByID(int blueprintID)
        {
            return null;
        }

        public void RazeConstructionSite(NWPlayer player, NWPlaceable structure, bool recoverMaterials)
        {
        }

        public NWPlaceable CompleteStructure(NWPlaceable site)
        {
            return null;
        }

        public void LogQuickBuildAction(NWPlayer dm, NWPlaceable completedStructure)
        {
        }

        public void SelectBlueprint(NWPlayer player, NWPlaceable site, int blueprintID)
        {
        }

        public List<BuildingInterior> GetBuildingInteriorsByCategoryID(int buildingCategoryID)
        {
            return null;
        }

        public void PreviewBuildingInterior(NWPlayer player, int buildingInteriorID)
        {
        }

        public void SetStructureCustomName(NWPlayer player, NWPlaceable structure, string customName)
        {
        }

        public List<PCTerritoryFlagsPermission> GetPermissionsByFlagID(int flagID)
        {
            return null;
        }

        public List<PCTerritoryFlagsPermission> GetPermissionsByPlayerID(string playerID, int flagID)
        {
            return null;
        }

        public List<TerritoryFlagPermission> GetAllTerritorySelectablePermissions()
        {
            return null;
        }

        public void RazeTerritory(NWPlaceable flag)
        {
        }

        public void TransferBuildingOwnership(NWArea area, string newOwnerPlayerID)
        {
        }

        public void TransferTerritoryOwnership(NWPlaceable flag, string newOwnerPlayerID)
        {
        }

        public List<StructureCategory> GetStructureCategories(string playerID)
        {
            return null;
        }

        public List<StructureBlueprint> GetStructuresForPCByCategory(string playerID, int structureCategoryID)
        {
            return null;
        }

        public void ChangeBuildPrivacy(int flagID, int buildPrivacyID)
        {
            PCTerritoryFlag entity = GetPCTerritoryFlagByID(flagID);
            entity.BuildPrivacySettingID = buildPrivacyID;
            _db.SaveChanges();
        }

        public void TogglePermissionForPlayer(PCTerritoryFlagsPermission foundPerm, string playerID, int permissionID, int flagID)
        {
            if (foundPerm == null)
            {
                PCTerritoryFlagsPermission perm = new PCTerritoryFlagsPermission
                {
                    PlayerID = playerID,
                    TerritoryFlagPermissionID = permissionID,
                    PCTerritoryFlagID = flagID
                };

                _db.PCTerritoryFlagsPermissions.Add(perm);
            }
            else
            {
                _db.PCTerritoryFlagsPermissions.Remove(foundPerm);
            }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
