using System;
using System.Collections.Generic;

#nullable disable

namespace Conquer.sakila
{
    public partial class Guild
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeaderId { get; set; }
        public string LeaderName { get; set; }
        public string Bulletin { get; set; }
        public int Fund { get; set; }
        public int Wins { get; set; }
        public int Members { get; set; }
        public bool LastWinner { get; set; }
        public int Gwpoints { get; set; }
        public int GuildPoints { get; set; }
    }
}
