namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AuthorizedDM
    {
        public int AuthorizedDMID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string CDKey { get; set; }

        public int DMRole { get; set; }

        public bool IsActive { get; set; }
    }
}
