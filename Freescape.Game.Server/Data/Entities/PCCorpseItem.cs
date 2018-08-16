using System.ComponentModel.DataAnnotations;

namespace Freescape.Game.Server.Data.Entities
{
    public partial class PCCorpseItem
    {
        public long PCCorpseItemID { get; set; }

        public long PCCorpseID { get; set; }

        [Required]
        public string NWItemObject { get; set; }

        public virtual PCCorpse PcCorpse { get; set; }
    }
}
