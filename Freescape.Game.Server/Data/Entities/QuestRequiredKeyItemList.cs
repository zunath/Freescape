namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestRequiredKeyItemList")]
    public partial class QuestRequiredKeyItemList
    {
        [Key]
        public int QuestRequiredKeyItemID { get; set; }

        public int QuestID { get; set; }

        public int KeyItemID { get; set; }

        public int QuestStateID { get; set; }

        public virtual KeyItem KeyItem { get; set; }

        public virtual QuestState QuestState { get; set; }

        public virtual Quest Quest { get; set; }
    }
}