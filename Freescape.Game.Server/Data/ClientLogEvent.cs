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
    
    public partial class ClientLogEvent
    {
        public int ClientLogEventID { get; set; }
        public int ClientLogEventTypeID { get; set; }
        public string PlayerID { get; set; }
        public string CDKey { get; set; }
        public string AccountName { get; set; }
        public System.DateTime DateOfEvent { get; set; }
    
        public virtual ClientLogEventTypesDomain ClientLogEventTypesDomain { get; set; }
        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
