using System;
using System.Collections.Generic;

#nullable disable

namespace Conquer.sakila
{
    public partial class Guildstatue
    {
        public long Uid { get; set; }
        public string Name { get; set; }
        public int Mesh { get; set; }
        public int? GuildId { get; set; }
        public int? GuildRank { get; set; }
        public int? Headgear { get; set; }
        public int? Necklace { get; set; }
        public int? Ring { get; set; }
        public int? RightHand { get; set; }
        public int? LeftHand { get; set; }
        public int? Garment { get; set; }
        public int? Armor { get; set; }
        public int? Hair { get; set; }
        public int Map { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? Frame { get; set; }
        public int? Direction { get; set; }
        public int? Action { get; set; }
        public int? ArmorColor { get; set; }
        public int? LeftHandColor { get; set; }
        public int? HeadgearColor { get; set; }
        public int CurHp { get; set; }
        public int MaxHp { get; set; }
    }
}
