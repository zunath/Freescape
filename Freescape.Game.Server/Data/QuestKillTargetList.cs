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
    
    public partial class QuestKillTargetList
    {
        public int QuestKillTargetListID { get; set; }
        public int QuestID { get; set; }
        public int NPCGroupID { get; set; }
        public int Quantity { get; set; }
        public int QuestStateID { get; set; }
    
        public virtual NPCGroup NPCGroup { get; set; }
        public virtual Quest Quest { get; set; }
        public virtual QuestState QuestState { get; set; }
    }
}
