using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conquer.Dtos
{
    public class LoginDto
    {
        public int UID { get; set; }
        [Required]
        [MaxLength(12)]
        [MinLength(4)]
        public string Username { get; set; }
        public int Status { get; set; }
        public long LastChangePassword { get; set; }
    }
}
