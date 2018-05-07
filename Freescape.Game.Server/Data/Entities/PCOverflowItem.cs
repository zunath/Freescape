namespace Freescape.Game.Server.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class PCOverflowItem
    {
        public long PCOverflowItemID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        [StringLength(64)]
        public string ItemTag { get; set; }

        [Required]
        [StringLength(16)]
        public string ItemResref { get; set; }

        [Required]
        public byte[] ItemObject { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
