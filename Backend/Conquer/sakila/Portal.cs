using System;
using System.Collections.Generic;

#nullable disable

namespace NovaGaming.sakila
{
    public partial class Portal
    {
        public int Id { get; set; }
        public int PortalMapId { get; set; }
        public int PortalX { get; set; }
        public int PortalY { get; set; }
        public int DestinationMapId { get; set; }
        public int DestinationX { get; set; }
        public int DestinationY { get; set; }
    }
}
