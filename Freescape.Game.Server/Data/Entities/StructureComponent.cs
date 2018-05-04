namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StructureComponent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StructureComponent()
        {
            ConstructionSiteComponents = new HashSet<ConstructionSiteComponent>();
        }

        public int StructureComponentID { get; set; }

        public int StructureBlueprintID { get; set; }

        [Required]
        [StringLength(16)]
        public string Resref { get; set; }

        public int Quantity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConstructionSiteComponent> ConstructionSiteComponents { get; set; }

        public virtual StructureBlueprint StructureBlueprint { get; set; }
    }
}
