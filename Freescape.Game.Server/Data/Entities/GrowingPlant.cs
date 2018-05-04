namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GrowingPlant
    {
        public int GrowingPlantID { get; set; }

        public int PlantID { get; set; }

        public int RemainingTicks { get; set; }

        [Required]
        [StringLength(64)]
        public string LocationAreaTag { get; set; }

        [Required]
        [StringLength(64)]
        public string LocationX { get; set; }

        [Required]
        [StringLength(64)]
        public string LocationY { get; set; }

        [Required]
        [StringLength(64)]
        public string LocationZ { get; set; }

        [Required]
        [StringLength(64)]
        public string LocationOrientation { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }

        public int TotalTicks { get; set; }

        public int WaterStatus { get; set; }

        public int LongevityBonus { get; set; }

        public virtual Plant Plant { get; set; }
    }
}
