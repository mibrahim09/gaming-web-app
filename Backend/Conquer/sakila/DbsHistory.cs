using System;
using System.Collections.Generic;

#nullable disable

namespace NovaGaming.sakila
{
    public partial class DbsHistory
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public string Email { get; set; }
        public int? Dbscrolls { get; set; }
        public string PayDate { get; set; }
    }
}
