namespace Freescape.Game.Server.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PCQuestKillTargetProgress")]
    public partial class PCQuestKillTargetProgress
    {
        public int PCQuestKillTargetProgressID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int PCQuestStatusID { get; set; }

        public int NPCGroupID { get; set; }

        public int RemainingToKill { get; set; }

        public virtual NPCGroup NPCGroup { get; set; }

        public virtual PCQuestStatu PCQuestStatu { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
