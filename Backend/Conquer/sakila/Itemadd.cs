using System;
using System.Collections.Generic;

#nullable disable

namespace NovaGaming.sakila
{
    public partial class Itemadd
    {
        public int UniqueId { get; set; }
        public int BaseId { get; set; }
        public byte Plus { get; set; }
        public int Health { get; set; }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int Defense { get; set; }
        public int MagicDamage { get; set; }
        public int MagicDefense { get; set; }
        public int Accuracy { get; set; }
        public byte Dodge { get; set; }
    }
}
