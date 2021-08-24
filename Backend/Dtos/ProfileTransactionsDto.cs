using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaGaming.Dtos
{
    public class ProfileTransactionsDto
    {
        public string TxnId { get; set; }
        public string ItemName { get; set; }
        public DateTime? Date { get; set; }
        public int? Claimed { get; set; }
        public string PaymentGross { get; set; }
        public string PaymentStatus { get; set; }
    }
}
