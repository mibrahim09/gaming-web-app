using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conquer.Models
{
    public class ChangePassword
    {
        [Required]
        [MinLength(4)]
        [MaxLength(12)]
        public string OldPassword { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(12)]
        public string NewPassword { get; set; }

    }
}
