using System;
using System.Collections.Generic;

#nullable disable

namespace NovaGaming.sakila
{
    public partial class Event
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public string Name { get; set; }
        public int Face { get; set; }
        public int EventType { get; set; }
        public int Rank { get; set; }
        public byte Claimed { get; set; }
    }
}
