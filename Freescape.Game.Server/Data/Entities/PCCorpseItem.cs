namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCCorpseItem
    {
        public long PCCorpseItemID { get; set; }

        public long PCCorpseID { get; set; }

        [Required]
        public byte[] NWItemObject { get; set; }

        public virtual PCCorps PCCorps { get; set; }
    }
}
