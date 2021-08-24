using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace NovaGaming.sakila
{
    public partial class Account
    {
        public int Uid { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Status { get; set; }
        public DateTime? Creation { get; set; }
        public string TokenChangePass { get; set; }
        public string Ip { get; set; }
        public int? IsOnline { get; set; }
        public string Ign { get; set; }
        public long LastChangePassword { get; set; }
    }
}
