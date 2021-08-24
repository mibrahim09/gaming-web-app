using System;
using System.Collections.Generic;

#nullable disable

namespace Conquer.sakila
{
    public partial class DbsError
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public string Error { get; set; }
        public string PayDate { get; set; }
        public DateTime? ErrorDate { get; set; }
        public string Email { get; set; }
        public int? Dbscrolls { get; set; }
    }
}
