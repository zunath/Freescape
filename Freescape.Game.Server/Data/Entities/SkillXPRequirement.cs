namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkillXPRequirement")]
    public partial class SkillXPRequirement
    {
        public int SkillXPRequirementID { get; set; }

        public int SkillID { get; set; }

        public int Rank { get; set; }

        public int XP { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
