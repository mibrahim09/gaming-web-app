using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conquer.Dtos
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(12)]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [MaxLength(12)]
        [MinLength(4)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(4)]
        public string Email { get; set; }

        public long LastChangePassword { get; set; }
    }
}
