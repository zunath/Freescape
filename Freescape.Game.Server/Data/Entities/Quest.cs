namespace Freescape.Game.Server.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Quest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quest()
        {
            PCQuestStatus = new HashSet<PCQuestStatu>();
            QuestKillTargetLists = new HashSet<QuestKillTargetList>();
            QuestPrerequisites = new HashSet<QuestPrerequisite>();
            QuestPrerequisites1 = new HashSet<QuestPrerequisite>();
            QuestRequiredItemLists = new HashSet<QuestRequiredItemList>();
            QuestRequiredKeyItemLists = new HashSet<QuestRequiredKeyItemList>();
            QuestRewardItems = new HashSet<QuestRewardItem>();
            QuestStates = new HashSet<QuestState>();
        }

        public int QuestID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(32)]
        public string JournalTag { get; set; }

        public int FameRegionID { get; set; }

        public int RequiredFameAmount { get; set; }

        public bool AllowRewardSelection { get; set; }

        public int RewardGold { get; set; }

        public int RewardXP { get; set; }

        public int? RewardKeyItemID { get; set; }

        public int RewardFame { get; set; }

        public bool IsRepeatable { get; set; }

        [Required]
        [StringLength(32)]
        public string MapNoteTag { get; set; }

        public int? StartKeyItemID { get; set; }

        public bool RemoveStartKeyItemAfterCompletion { get; set; }

        public virtual FameRegion FameRegion { get; set; }

        public virtual KeyItem KeyItem { get; set; }

        public virtual KeyItem KeyItem1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PCQuestStatu> PCQuestStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestKillTargetList> QuestKillTargetLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestPrerequisite> QuestPrerequisites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestPrerequisite> QuestPrerequisites1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestRequiredItemList> QuestRequiredItemLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestRequiredKeyItemList> QuestRequiredKeyItemLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestRewardItem> QuestRewardItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestState> QuestStates { get; set; }
    }
}
