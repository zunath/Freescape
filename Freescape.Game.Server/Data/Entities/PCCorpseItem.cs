namespace Freescape.Game.Server.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class PCCorpseItem
    {
        public long PCCorpseItemID { get; set; }

        public long PCCorpseID { get; set; }

        [Required]
        public byte[] NWItemObject { get; set; }

        public virtual PCCorps PCCorps { get; set; }
    }
}
