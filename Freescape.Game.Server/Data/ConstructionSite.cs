//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Freescape.Game.Server.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConstructionSite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConstructionSite()
        {
            this.ConstructionSiteComponents = new HashSet<ConstructionSiteComponent>();
        }
    
        public int ConstructionSiteID { get; set; }
        public Nullable<int> PCTerritoryFlagID { get; set; }
        public string PlayerID { get; set; }
        public int StructureBlueprintID { get; set; }
        public string LocationAreaTag { get; set; }
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double LocationZ { get; set; }
        public double LocationOrientation { get; set; }
        public Nullable<int> BuildingInteriorID { get; set; }
        public bool IsActive { get; set; }
    
        public virtual BuildingInterior BuildingInterior { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConstructionSiteComponent> ConstructionSiteComponents { get; set; }
        public virtual PCTerritoryFlag PCTerritoryFlag { get; set; }
        public virtual PlayerCharacter PlayerCharacter { get; set; }
        public virtual StructureBlueprint StructureBlueprint { get; set; }
    }
}