namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCMapPin
    {
        public int PCMapPinID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        [Required]
        [StringLength(32)]
        public string AreaTag { get; set; }

        public double PositionX { get; set; }

        public double PositionY { get; set; }

        [Required]
        [StringLength(1024)]
        public string NoteText { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}