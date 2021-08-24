using System;
using System.Collections.Generic;

#nullable disable

namespace Conquer.sakila
{
    public partial class DailySilversLog
    {
        public DateTime? Date { get; set; }
        public long? PickedSilvers { get; set; }
        public long? DailyMeteors { get; set; }
        public long? DailyDbs { get; set; }
        public long? BlueMouseMets { get; set; }
    }
}
