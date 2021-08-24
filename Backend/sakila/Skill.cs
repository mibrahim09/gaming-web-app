using System;
using System.Collections.Generic;

#nullable disable

namespace NovaGaming.sakila
{
    public partial class Skill
    {
        public int? Owner { get; set; }
        public int? Id { get; set; }
        public int? Level { get; set; }
        public double? Exp { get; set; }
        public int? PreviousLevel { get; set; }
    }
}
