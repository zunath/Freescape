namespace Freescape.Game.Server.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class LootTableItem
    {
        public int LootTableItemID { get; set; }

        public int LootTableID { get; set; }

        [Required]
        [StringLength(16)]
        public string Resref { get; set; }

        public int MaxQuantity { get; set; }

        public byte Weight { get; set; }

        public bool IsActive { get; set; }

        public virtual LootTable LootTable { get; set; }
    }
}
