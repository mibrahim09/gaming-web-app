using System;
using System.Collections.Generic;

#nullable disable

namespace Conquer.sakila
{
    public partial class VotesAccount
    {
        public string Username { get; set; }
        public int? Claims { get; set; }
        public int? Total { get; set; }
        public string Name { get; set; }
        public DateTime LastClaim { get; set; }
    }
}
