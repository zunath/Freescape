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
    
    public partial class CraftBlueprintComponent
    {
        public long CraftComponentID { get; set; }
        public long CraftBlueprintID { get; set; }
        public string ItemResref { get; set; }
        public int Quantity { get; set; }
    
        public virtual CraftBlueprint CraftBlueprint { get; set; }
    }
}
