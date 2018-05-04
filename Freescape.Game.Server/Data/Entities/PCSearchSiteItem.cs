namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCSearchSiteItem
    {
        public long PCSearchSiteItemID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int SearchSiteID { get; set; }

        [Required]
        public byte[] SearchItem { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
