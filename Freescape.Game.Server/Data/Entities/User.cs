namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public long UserID { get; set; }

        [Required]
        public string DiscordUserID { get; set; }

        [Required]
        [StringLength(32)]
        public string Username { get; set; }

        [Required]
        public string AvatarHash { get; set; }

        [Required]
        [StringLength(4)]
        public string Discriminator { get; set; }

        [Required]
        public string Email { get; set; }

        public int RoleID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateRegistered { get; set; }

        public virtual DMRoleDomain DMRoleDomain { get; set; }
    }
}
