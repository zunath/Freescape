namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestRequiredItemList")]
    public partial class QuestRequiredItemList
    {
        public int QuestRequiredItemListID { get; set; }

        public int QuestID { get; set; }

        [Required]
        [StringLength(16)]
        public string Resref { get; set; }

        public int Quantity { get; set; }

        public int QuestStateID { get; set; }

        public virtual QuestState QuestState { get; set; }

        public virtual Quest Quest { get; set; }
    }
}
