//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Freescape.Game.Server.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PCCustomEffect
    {
        public long PCCustomEffectID { get; set; }
        public string PlayerID { get; set; }
        public long CustomEffectID { get; set; }
        public int Ticks { get; set; }
    
        public virtual CustomEffect CustomEffect { get; set; }
        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
