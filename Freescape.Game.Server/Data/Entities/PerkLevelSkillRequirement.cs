namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PerkLevelSkillRequirement
    {
        public int PerkLevelSkillRequirementID { get; set; }

        public int PerkLevelID { get; set; }

        public int SkillID { get; set; }

        public int RequiredRank { get; set; }

        public virtual PerkLevel PerkLevel { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
