namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConstructionSite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConstructionSite()
        {
            ConstructionSiteComponents = new HashSet<ConstructionSiteComponent>();
        }

        public int ConstructionSiteID { get; set; }

        public int? PCTerritoryFlagID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int StructureBlueprintID { get; set; }

        [Required]
        [StringLength(64)]
        public string LocationAreaTag { get; set; }

        public double LocationX { get; set; }

        public double LocationY { get; set; }

        public double LocationZ { get; set; }

        public double LocationOrientation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConstructionSiteComponent> ConstructionSiteComponents { get; set; }

        public virtual PCTerritoryFlag PCTerritoryFlag { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }

        public virtual StructureBlueprint StructureBlueprint { get; set; }
    }
}