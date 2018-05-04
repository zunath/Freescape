namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Plant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plant()
        {
            GrowingPlants = new HashSet<GrowingPlant>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlantID { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        public int BaseTicks { get; set; }

        [Required]
        [StringLength(16)]
        public string Resref { get; set; }

        public int WaterTicks { get; set; }

        public int Level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrowingPlant> GrowingPlants { get; set; }
    }
}