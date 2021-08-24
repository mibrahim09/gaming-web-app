using System;
using System.Collections.Generic;

#nullable disable

namespace Conquer.sakila
{
    public partial class LogPayment
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Log { get; set; }
        public DateTime? Date { get; set; }
    }
}
