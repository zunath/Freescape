namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServerConfiguration")]
    public partial class ServerConfiguration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServerConfigurationID { get; set; }

        [Required]
        [StringLength(50)]
        public string ServerName { get; set; }

        [Required]
        [StringLength(1024)]
        public string MessageOfTheDay { get; set; }
    }
}
