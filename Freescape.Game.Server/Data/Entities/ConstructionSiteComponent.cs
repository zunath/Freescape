namespace Freescape.Game.Server.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConstructionSiteComponent
    {
        public int ConstructionSiteComponentID { get; set; }

        public int ConstructionSiteID { get; set; }

        public int Quantity { get; set; }

        public int StructureComponentID { get; set; }

        public virtual ConstructionSite ConstructionSite { get; set; }

        public virtual StructureComponent StructureComponent { get; set; }
    }
}
