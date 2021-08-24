using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaGaming.Models
{
    public class ServerStatistics
    {
        public string ServerStatus { get; set; }
        public int OnlinePlayers { get; set; }
        public string LastGuildWarWinner { get; set; }
        public string LastCounterClockWinner { get; set; }
        public string LastTwinCityWinner { get; set; }
    }
}
