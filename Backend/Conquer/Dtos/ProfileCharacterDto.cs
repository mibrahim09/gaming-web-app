using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaGaming.Dtos
{
    public class ProfileCharacterDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Spouse { get; set; }
        public int Body { get; set; }
        public int Face { get; set; }
        public int Hair { get; set; }
        public int Silvers { get; set; }
        public int Whsilvers { get; set; }
        public int Cps { get; set; }
        public int? Reborns { get; set; }
        public int Job { get; set; }
        public DateTime? VipendDate { get; set; }
        public int Viplevel { get; set; }
        public int Pkpoints { get; set; }
        public int VotePoints { get; set; }
    }
}
