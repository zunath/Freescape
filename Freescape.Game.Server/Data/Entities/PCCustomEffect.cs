namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PCCustomEffect
    {
        public long PCCustomEffectID { get; set; }

        [Required]
        [StringLength(60)]
        public string PlayerID { get; set; }

        public long CustomEffectID { get; set; }

        public int Ticks { get; set; }

        public virtual CustomEffect CustomEffect { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
