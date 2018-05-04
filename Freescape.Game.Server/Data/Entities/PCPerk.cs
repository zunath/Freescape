namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCPerk
    {
        public int PCPerkID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AcquiredDate { get; set; }

        public int PerkID { get; set; }

        public int PerkLevel { get; set; }

        public virtual Perk Perk { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
