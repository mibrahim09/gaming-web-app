using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conquer.Dtos
{
    public class ProfileUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public DateTime? Creation { get; set; }
        public string Ip { get; set; }
        public int? IsOnline { get; set; }
        public string Ign { get; set; }
    }
}
