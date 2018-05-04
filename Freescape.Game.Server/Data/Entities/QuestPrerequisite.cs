namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuestPrerequisite
    {
        public int QuestPrerequisiteID { get; set; }

        public int QuestID { get; set; }

        public int RequiredQuestID { get; set; }

        public virtual Quest Quest { get; set; }

        public virtual Quest Quest1 { get; set; }
    }
}
