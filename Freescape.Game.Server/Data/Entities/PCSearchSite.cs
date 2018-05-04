namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCSearchSite
    {
        public int PCSearchSiteID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int SearchSiteID { get; set; }

        public DateTime UnlockDateTime { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
