using Freescape.Game.Server.Data;
using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.GameObject.Contracts;
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
        void JumpPCToBuildingInterior(NWPlayer oPC, NWArea instance);
    }
}
