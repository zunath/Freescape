namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCSkill
    {
        public int PCSkillID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public int SkillID { get; set; }

        public int XP { get; set; }

        public int Rank { get; set; }

        public bool IsLocked { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
