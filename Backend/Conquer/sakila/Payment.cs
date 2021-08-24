using System;
using System.Collections.Generic;

#nullable disable

namespace Conquer.sakila
{
    public partial class Payment
    {
        public string Username { get; set; }
        public string TxnId { get; set; }
        public int? ItemNumber { get; set; }
        public string ItemName { get; set; }
        public DateTime? Date { get; set; }
        public int? Claimed { get; set; }
        public string PaymentGross { get; set; }
        public string McGross { get; set; }
        public string PayerId { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
    }
}
