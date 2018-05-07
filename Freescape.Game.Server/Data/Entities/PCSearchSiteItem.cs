namespace Freescape.Game.Server.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

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
