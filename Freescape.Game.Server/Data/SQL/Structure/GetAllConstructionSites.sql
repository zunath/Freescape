
SELECT cs.ConstructionSiteID ,
       cs.PCTerritoryFlagID ,
       cs.PlayerID ,
       cs.StructureBlueprintID ,
       cs.LocationAreaTag ,
       cs.LocationX ,
       cs.LocationY ,
       cs.LocationZ ,
       cs.LocationOrientation
FROM dbo.ConstructionSites cs
