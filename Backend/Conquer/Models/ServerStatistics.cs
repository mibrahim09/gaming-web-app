﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conquer.Models
{
    public class ServerStatistics
    {
        public bool IsOnline { get; set; }
        public string LastGuildWarWinner { get; set; }
        public string LastCounterClockWinner { get; set; }
        public string LastTwinCityWinner{ get; set; }
    }
}
