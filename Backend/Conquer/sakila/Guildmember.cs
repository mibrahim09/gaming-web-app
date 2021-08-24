using System;
using System.Collections.Generic;

#nullable disable

namespace Conquer.sakila
{
    public partial class Guildmember
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int Donation { get; set; }
        public int Level { get; set; }
        public short Rank { get; set; }
        public int GuildId { get; set; }
    }
}
