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
    
    public partial class PCTerritoryFlagsStructuresItem
    {
        public long PCStructureItemID { get; set; }
        public long PCStructureID { get; set; }
        public string ItemName { get; set; }
        public string ItemTag { get; set; }
        public string ItemResref { get; set; }
        public byte[] ItemObject { get; set; }
        public string GlobalID { get; set; }
    
        public virtual PCTerritoryFlagsStructure PCTerritoryFlagsStructure { get; set; }
    }
}
