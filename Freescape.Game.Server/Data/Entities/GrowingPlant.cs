using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Freescape.Game.Server.Data.Entities
{
    public partial class GrowingPlant
    {
        public int GrowingPlantID { get; set; }

        public int PlantID { get; set; }

        public int RemainingTicks { get; set; }

        [Required]
        [StringLength(64)]
        public string LocationAreaTag { get; set; }

        public float LocationX { get; set; }
        public float LocationY { get; set; }
        public float LocationZ { get; set; }
        public float LocationOrientation { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }

        public int TotalTicks { get; set; }

        public int WaterStatus { get; set; }

        public int LongevityBonus { get; set; }

        public virtual Plant Plant { get; set; }
    }
}
