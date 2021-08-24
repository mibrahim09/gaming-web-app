using System;
using System.Collections.Generic;

#nullable disable

namespace Conquer.sakila
{
    public partial class Customdialog
    {
        public int Uid { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Permanent { get; set; }
        public bool PopUp { get; set; }
        public bool SystemMenu { get; set; }
        public bool? StretchBg { get; set; }
        public int ButtonCount { get; set; }
    }
}
