using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovaGaming.Models
{
    public class ForgotPassword
    {
        [Required]
        [MinLength(4)]
        [MaxLength(12)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
