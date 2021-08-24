using System;
using System.Collections.Generic;

#nullable disable

namespace NovaGaming.sakila
{
    public partial class Guildrelation
    {
        public int Id { get; set; }
        public int Guilduid { get; set; }
        public int Associateuid { get; set; }
        public string Associatename { get; set; }
        public byte Type { get; set; }
    }
}
