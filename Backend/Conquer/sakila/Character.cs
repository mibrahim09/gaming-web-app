using System;
using System.Collections.Generic;

#nullable disable

namespace Conquer.sakila
{
    public partial class Character
    {
        public int Uid { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public string Spouse { get; set; }
        public int Body { get; set; }
        public int Face { get; set; }
        public int Hair { get; set; }
        public int Silvers { get; set; }
        public int Whsilvers { get; set; }
        public int Cps { get; set; }
        public int GuildId { get; set; }
        public int Version { get; set; }
        public int Map { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? Reborns { get; set; }
        public int Job { get; set; }
        public int PreviousJob1 { get; set; }
        public int PreviousJob2 { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Vitality { get; set; }
        public int Spirit { get; set; }
        public int ExtraStats { get; set; }
        public int Life { get; set; }
        public int Mana { get; set; }
        public int VirtuePoints { get; set; }
        public int Dbscrolls { get; set; }
        public int Top { get; set; }
        public bool DoubleExp { get; set; }
        public int DoubleExpLeft { get; set; }
        public string Whpassword { get; set; }
        public DateTime? VipendDate { get; set; }
        public int Viplevel { get; set; }
        public DateTime Vip { get; set; }
        public int PumpkinPoints { get; set; }
        public int TreasurePoints { get; set; }
        public int Ctbpoints { get; set; }
        public int MetScrolls { get; set; }
        public int OnlineTime { get; set; }
        public int CurrentKills { get; set; }
        public long Nobility { get; set; }
        public int Pkpoints { get; set; }
        public int VotePoints { get; set; }
        public int ClassicPoints { get; set; }
        public bool? PassiveSkills { get; set; }
        public DateTime HeavensBlessing { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime BotjailedTime { get; set; }
        public int? BotJailedDays { get; set; }
        public bool? Voted { get; set; }
        public int MutedRecord { get; set; }
        public DateTime MutedTime { get; set; }
        public int CurrentHonor { get; set; }
        public int TotalHonor { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public int PreviousMap { get; set; }
        public bool? Warning { get; set; }
        public bool? TopFb { get; set; }
    }
}
