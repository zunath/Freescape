namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuestState
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestState()
        {
            PCQuestStatus = new HashSet<PCQuestStatu>();
            QuestKillTargetLists = new HashSet<QuestKillTargetList>();
            QuestRequiredItemLists = new HashSet<QuestRequiredItemList>();
            QuestRequiredKeyItemLists = new HashSet<QuestRequiredKeyItemList>();
        }

        public int QuestStateID { get; set; }

        public int QuestID { get; set; }

        public int Sequence { get; set; }

        public int QuestTypeID { get; set; }

        public int JournalStateID { get; set; }

        public bool IsFinalState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCQuestStatu> PCQuestStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestKillTargetList> QuestKillTargetLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestRequiredItemList> QuestRequiredItemLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestRequiredKeyItemList> QuestRequiredKeyItemLists { get; set; }

        public virtual Quest Quest { get; set; }

        public virtual QuestTypeDomain QuestTypeDomain { get; set; }
    }
}
