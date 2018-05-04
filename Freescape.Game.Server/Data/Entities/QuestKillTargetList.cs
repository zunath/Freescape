namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestKillTargetList")]
    public partial class QuestKillTargetList
    {
        public int QuestKillTargetListID { get; set; }

        public int QuestID { get; set; }

        public int NPCGroupID { get; set; }

        public int Quantity { get; set; }

        public int QuestStateID { get; set; }

        public virtual NPCGroup NPCGroup { get; set; }

        public virtual Quest Quest { get; set; }

        public virtual QuestState QuestState { get; set; }
    }
}
