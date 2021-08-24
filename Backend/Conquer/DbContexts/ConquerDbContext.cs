using System;
using Microsoft.Extensions.Configuration;
using Conquer.sakila;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Conquer.DbContexts
{
    public partial class ConquerDbContext : DbContext
    {

        public ConquerDbContext(DbContextOptions<ConquerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Arena> Arenas { get; set; }
        public virtual DbSet<Bannedchar> Bannedchars { get; set; }
        public virtual DbSet<Cfg> Cfgs { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Citywar> Citywars { get; set; }
        public virtual DbSet<Custombutton> Custombuttons { get; set; }
        public virtual DbSet<Customdialog> Customdialogs { get; set; }
        public virtual DbSet<Customshop> Customshops { get; set; }
        public virtual DbSet<DailySilversLog> DailySilversLogs { get; set; }
        public virtual DbSet<DbsError> DbsErrors { get; set; }
        public virtual DbSet<DbsHistory> DbsHistories { get; set; }
        public virtual DbSet<DropStat> DropStats { get; set; }
        public virtual DbSet<Dynamicmap> Dynamicmaps { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Furniture> Furnitures { get; set; }
        public virtual DbSet<Guild> Guilds { get; set; }
        public virtual DbSet<Guildmember> Guildmembers { get; set; }
        public virtual DbSet<Guildrelation> Guildrelations { get; set; }
        public virtual DbSet<Guildstatue> Guildstatues { get; set; }
        public virtual DbSet<GwVisitor> GwVisitors { get; set; }
        public virtual DbSet<Itemadd> Itemadds { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LogPayment> LogPayments { get; set; }
        public virtual DbSet<Npc> Npcs { get; set; }
        public virtual DbSet<NpcsCopy1> NpcsCopy1s { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Portal> Portals { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Stat> Stats { get; set; }
        public virtual DbSet<Top> Tops { get; set; }
        public virtual DbSet<VoteHistory> VoteHistories { get; set; }
        public virtual DbSet<VotesAccount> VotesAccounts { get; set; }
        public virtual DbSet<VotesIp> VotesIps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => new { e.Uid, e.Username })
                    .HasName("PRIMARY");

                entity.ToTable("accounts");

                entity.HasIndex(e => e.Uid, "UID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "Username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UID");

                entity.Property(e => e.Username).HasMaxLength(16);

                entity.Property(e => e.Answer).HasMaxLength(32);

                entity.Property(e => e.Email).HasMaxLength(64);

                entity.Property(e => e.Ign)
                    .HasMaxLength(255)
                    .HasColumnName("IGN");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .HasColumnName("ip");

                entity.Property(e => e.IsOnline)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Question).HasMaxLength(32);

                entity.Property(e => e.Status).HasColumnType("int(4)");

                entity.Property(e => e.TokenChangePass).HasMaxLength(255);
            });

            modelBuilder.Entity<Arena>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("arena");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("UID");

                entity.Property(e => e.Face).HasColumnType("int(11) unsigned");

                entity.Property(e => e.Job)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("'None'");

                entity.Property(e => e.Level)
                    .HasColumnType("int(4) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("'None'");

                entity.Property(e => e.Points).HasColumnType("int(6) unsigned");

                entity.Property(e => e.Rank).HasColumnType("int(4) unsigned");
            });

            modelBuilder.Entity<Bannedchar>(entity =>
            {
                entity.HasKey(e => new { e.Uid, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("bannedchars");

                entity.HasIndex(e => e.Name, "Name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Uid, "UID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("UID");

                entity.Property(e => e.Name).HasMaxLength(16);

                entity.Property(e => e.Agility).HasColumnType("int(4)");

                entity.Property(e => e.Body).HasColumnType("int(11)");

                entity.Property(e => e.BotJailedDays)
                    .HasColumnType("int(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BotjailedTime).HasDefaultValueSql("'2011-01-25 11:36:12'");

                entity.Property(e => e.ClassicPoints).HasColumnType("int(4)");

                entity.Property(e => e.Cps)
                    .HasColumnType("int(11)")
                    .HasColumnName("CPs");

                entity.Property(e => e.Ctbpoints)
                    .HasColumnType("int(4)")
                    .HasColumnName("CTBPoints");

                entity.Property(e => e.CurrentHonor).HasColumnType("int(6) unsigned");

                entity.Property(e => e.CurrentKills).HasColumnType("int(4)");

                entity.Property(e => e.Dbscrolls)
                    .HasColumnType("int(6)")
                    .HasColumnName("DBScrolls");

                entity.Property(e => e.DoubleExpLeft).HasColumnType("int(11)");

                entity.Property(e => e.Experience).HasColumnType("int(22)");

                entity.Property(e => e.ExtraStats).HasColumnType("int(4)");

                entity.Property(e => e.Face).HasColumnType("int(11)");

                entity.Property(e => e.GuildId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GuildID");

                entity.Property(e => e.Hair).HasColumnType("int(3)");

                entity.Property(e => e.HeavensBlessing).HasDefaultValueSql("'2011-01-25 11:36:12'");

                entity.Property(e => e.Job).HasColumnType("int(4)");

                entity.Property(e => e.LastLogin).HasDefaultValueSql("'2011-01-25 11:36:12'");

                entity.Property(e => e.Level)
                    .HasColumnType("int(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Life).HasColumnType("int(6)");

                entity.Property(e => e.Mana).HasColumnType("int(6)");

                entity.Property(e => e.Map)
                    .HasColumnType("int(6)")
                    .HasDefaultValueSql("'1010'");

                entity.Property(e => e.MetScrolls).HasColumnType("int(4)");

                entity.Property(e => e.MutedRecord).HasColumnType("int(4) unsigned");

                entity.Property(e => e.MutedTime).HasDefaultValueSql("'2011-01-25 11:36:12'");

                entity.Property(e => e.Nobility).HasColumnType("bigint(100)");

                entity.Property(e => e.OnlineTime).HasColumnType("int(6)");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PassiveSkills)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Pkpoints)
                    .HasColumnType("int(4)")
                    .HasColumnName("PKPoints");

                entity.Property(e => e.PreviousJob1).HasColumnType("int(4)");

                entity.Property(e => e.PreviousJob2).HasColumnType("int(4)");

                entity.Property(e => e.PreviousMap).HasColumnType("int(6)");

                entity.Property(e => e.PumpkinPoints).HasColumnType("int(4)");

                entity.Property(e => e.Reborns)
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Silvers).HasColumnType("int(11)");

                entity.Property(e => e.Spirit).HasColumnType("int(4)");

                entity.Property(e => e.Spouse)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("'None'");

                entity.Property(e => e.Strength).HasColumnType("int(4)");

                entity.Property(e => e.Top)
                    .HasColumnType("int(6)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.TopFb)
                    .HasColumnName("TopFB")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.TotalHonor).HasColumnType("int(6) unsigned");

                entity.Property(e => e.TotalLosses).HasColumnType("int(6) unsigned");

                entity.Property(e => e.TotalWins).HasColumnType("int(6) unsigned");

                entity.Property(e => e.TreasurePoints).HasColumnType("int(4)");

                entity.Property(e => e.Version)
                    .HasColumnType("int(4) unsigned")
                    .HasDefaultValueSql("'1039'");

                entity.Property(e => e.Vip)
                    .HasColumnName("VIP")
                    .HasDefaultValueSql("'2011-01-25 11:36:12'");

                entity.Property(e => e.VipendDate).HasColumnName("VIPEndDate");

                entity.Property(e => e.Viplevel)
                    .HasColumnType("int(4)")
                    .HasColumnName("VIPLevel");

                entity.Property(e => e.VirtuePoints).HasColumnType("int(5)");

                entity.Property(e => e.Vitality).HasColumnType("int(4)");

                entity.Property(e => e.VotePoints).HasColumnType("int(4)");

                entity.Property(e => e.Voted).HasDefaultValueSql("'0'");

                entity.Property(e => e.Warning).HasDefaultValueSql("'0'");

                entity.Property(e => e.Whpassword)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("WHPassword")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Whsilvers)
                    .HasColumnType("int(11)")
                    .HasColumnName("WHSilvers");

                entity.Property(e => e.X)
                    .HasColumnType("int(4)")
                    .HasDefaultValueSql("'61'");

                entity.Property(e => e.Y)
                    .HasColumnType("int(4)")
                    .HasDefaultValueSql("'109'");
            });

            modelBuilder.Entity<Cfg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cfg");

                entity.Property(e => e.Archers)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Online).HasColumnType("int(255)");

                entity.Property(e => e.Taos)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Trojans)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Warriors)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => new { e.Uid, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("characters");

                entity.HasIndex(e => e.Name, "Name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Uid, "UID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("UID");

                entity.Property(e => e.Name).HasMaxLength(16);

                entity.Property(e => e.Agility).HasColumnType("int(4)");

                entity.Property(e => e.Body).HasColumnType("int(11)");

                entity.Property(e => e.BotJailedDays)
                    .HasColumnType("int(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BotjailedTime).HasDefaultValueSql("'2011-01-25 11:36:12'");

                entity.Property(e => e.ClassicPoints).HasColumnType("int(4)");

                entity.Property(e => e.Cps)
                    .HasColumnType("int(11)")
                    .HasColumnName("CPs");

                entity.Property(e => e.Ctbpoints)
                    .HasColumnType("int(4)")
                    .HasColumnName("CTBPoints");

                entity.Property(e => e.CurrentHonor).HasColumnType("int(6) unsigned");

                entity.Property(e => e.CurrentKills).HasColumnType("int(4)");

                entity.Property(e => e.Dbscrolls)
                    .HasColumnType("int(6)")
                    .HasColumnName("DBScrolls");

                entity.Property(e => e.DoubleExpLeft).HasColumnType("int(11)");

                entity.Property(e => e.Experience).HasColumnType("int(22)");

                entity.Property(e => e.ExtraStats).HasColumnType("int(4)");

                entity.Property(e => e.Face).HasColumnType("int(11)");

                entity.Property(e => e.GuildId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GuildID");

                entity.Property(e => e.Hair).HasColumnType("int(3)");

                entity.Property(e => e.HeavensBlessing).HasDefaultValueSql("'2011-01-25 11:36:12'");

                entity.Property(e => e.Job).HasColumnType("int(4)");

                entity.Property(e => e.LastLogin).HasDefaultValueSql("'2011-01-25 11:36:12'");

                entity.Property(e => e.Level)
                    .HasColumnType("int(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Life).HasColumnType("int(6)");

                entity.Property(e => e.Mana).HasColumnType("int(6)");

                entity.Property(e => e.Map)
                    .HasColumnType("int(6)")
                    .HasDefaultValueSql("'1010'");

                entity.Property(e => e.MetScrolls).HasColumnType("int(4)");

                entity.Property(e => e.MutedRecord).HasColumnType("int(4) unsigned");

                entity.Property(e => e.MutedTime).HasDefaultValueSql("'2011-01-25 11:36:12'");

                entity.Property(e => e.Nobility).HasColumnType("bigint(100)");

                entity.Property(e => e.OnlineTime).HasColumnType("int(6)");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PassiveSkills)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Pkpoints)
                    .HasColumnType("int(4)")
                    .HasColumnName("PKPoints");

                entity.Property(e => e.PreviousJob1).HasColumnType("int(4)");

                entity.Property(e => e.PreviousJob2).HasColumnType("int(4)");

                entity.Property(e => e.PreviousMap).HasColumnType("int(6)");

                entity.Property(e => e.PumpkinPoints).HasColumnType("int(4)");

                entity.Property(e => e.Reborns)
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Silvers).HasColumnType("int(11)");

                entity.Property(e => e.Spirit).HasColumnType("int(4)");

                entity.Property(e => e.Spouse)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("'None'");

                entity.Property(e => e.Strength).HasColumnType("int(4)");

                entity.Property(e => e.Top)
                    .HasColumnType("int(6)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.TopFb)
                    .HasColumnName("TopFB")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.TotalHonor).HasColumnType("int(6) unsigned");

                entity.Property(e => e.TotalLosses).HasColumnType("int(6) unsigned");

                entity.Property(e => e.TotalWins).HasColumnType("int(6) unsigned");

                entity.Property(e => e.TreasurePoints).HasColumnType("int(4)");

                entity.Property(e => e.Version)
                    .HasColumnType("int(4) unsigned")
                    .HasDefaultValueSql("'1039'");

                entity.Property(e => e.Vip)
                    .HasColumnName("VIP")
                    .HasDefaultValueSql("'2011-01-25 11:36:12'");

                entity.Property(e => e.VipendDate).HasColumnName("VIPEndDate");

                entity.Property(e => e.Viplevel)
                    .HasColumnType("int(4)")
                    .HasColumnName("VIPLevel");

                entity.Property(e => e.VirtuePoints).HasColumnType("int(5)");

                entity.Property(e => e.Vitality).HasColumnType("int(4)");

                entity.Property(e => e.VotePoints).HasColumnType("int(4)");

                entity.Property(e => e.Voted).HasDefaultValueSql("'0'");

                entity.Property(e => e.Warning).HasDefaultValueSql("'0'");

                entity.Property(e => e.Whpassword)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("WHPassword")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Whsilvers)
                    .HasColumnType("int(11)")
                    .HasColumnName("WHSilvers");

                entity.Property(e => e.X)
                    .HasColumnType("int(4)")
                    .HasDefaultValueSql("'61'");

                entity.Property(e => e.Y)
                    .HasColumnType("int(4)")
                    .HasDefaultValueSql("'109'");
            });

            modelBuilder.Entity<Citywar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("citywars");

                entity.Property(e => e.Ac)
                    .HasColumnType("int(255)")
                    .HasColumnName("AC");

                entity.Property(e => e.Bi)
                    .HasColumnType("int(255)")
                    .HasColumnName("BI");

                entity.Property(e => e.Dc)
                    .HasColumnType("int(255)")
                    .HasColumnName("DC");

                entity.Property(e => e.Pc)
                    .HasColumnType("int(255)")
                    .HasColumnName("PC");
            });

            modelBuilder.Entity<Custombutton>(entity =>
            {
                entity.HasKey(e => new { e.Count, e.Uid })
                    .HasName("PRIMARY");

                entity.ToTable("custombuttons");

                entity.Property(e => e.Count)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("UID");

                entity.Property(e => e.AniHeight).HasColumnType("int(4)");

                entity.Property(e => e.AniWidth).HasColumnType("int(4)");

                entity.Property(e => e.DialogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DialogID");

                entity.Property(e => e.Height).HasColumnType("int(4)");

                entity.Property(e => e.TipColor).HasColumnType("int(11)");

                entity.Property(e => e.TipStr)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasDefaultValueSql("' '");

                entity.Property(e => e.Width).HasColumnType("int(4)");

                entity.Property(e => e.Xpos)
                    .HasColumnType("int(4)")
                    .HasColumnName("xpos");

                entity.Property(e => e.Ypos)
                    .HasColumnType("int(4)")
                    .HasColumnName("ypos");
            });

            modelBuilder.Entity<Customdialog>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("customdialogs");

                entity.HasIndex(e => e.Uid, "UID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("UID");

                entity.Property(e => e.ButtonCount).HasColumnType("int(4)");

                entity.Property(e => e.Height).HasColumnType("int(4)");

                entity.Property(e => e.StretchBg)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Width).HasColumnType("int(4)");

                entity.Property(e => e.X).HasColumnType("int(4)");

                entity.Property(e => e.Y).HasColumnType("int(4)");
            });

            modelBuilder.Entity<Customshop>(entity =>
            {
                entity.ToTable("customshop");

                entity.HasIndex(e => e.Id, "ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID");

                entity.Property(e => e.ItemUid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("ItemUID");

                entity.Property(e => e.Price).HasColumnType("int(4) unsigned");

                entity.Property(e => e.Type).HasColumnType("int(4) unsigned");
            });

            modelBuilder.Entity<DailySilversLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("daily_silvers_logs");

                entity.Property(e => e.BlueMouseMets).HasColumnType("bigint(255)");

                entity.Property(e => e.DailyDbs)
                    .HasColumnType("bigint(255)")
                    .HasColumnName("DailyDBs");

                entity.Property(e => e.DailyMeteors).HasColumnType("bigint(255)");

                entity.Property(e => e.Date).HasColumnType("datetime(6)");

                entity.Property(e => e.PickedSilvers).HasColumnType("bigint(255)");
            });

            modelBuilder.Entity<DbsError>(entity =>
            {
                entity.ToTable("dbs_errors");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CharacterName)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Dbscrolls)
                    .HasColumnType("int(4) unsigned")
                    .HasColumnName("DBSCrolls");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Error).HasMaxLength(45);

                entity.Property(e => e.PayDate).HasMaxLength(100);
            });

            modelBuilder.Entity<DbsHistory>(entity =>
            {
                entity.ToTable("dbs_history");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CharacterName)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Dbscrolls)
                    .HasColumnType("int(4) unsigned")
                    .HasColumnName("DBSCrolls");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PayDate).HasMaxLength(100);
            });

            modelBuilder.Entity<DropStat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("drop_stats");

                entity.Property(e => e.Dbs)
                    .HasColumnType("int(255) unsigned")
                    .HasColumnName("dbs");

                entity.Property(e => e.Elite)
                    .HasColumnType("int(255) unsigned")
                    .HasColumnName("elite");

                entity.Property(e => e.Gold)
                    .HasColumnType("int(255) unsigned")
                    .HasColumnName("gold");

                entity.Property(e => e.Meteors)
                    .HasColumnType("int(255) unsigned")
                    .HasColumnName("meteors");

                entity.Property(e => e.Mobs)
                    .HasColumnType("int(255) unsigned")
                    .HasColumnName("mobs");

                entity.Property(e => e.Plus)
                    .HasColumnType("int(255) unsigned")
                    .HasColumnName("plus");

                entity.Property(e => e.Super)
                    .HasColumnType("int(255) unsigned")
                    .HasColumnName("super");
            });

            modelBuilder.Entity<Dynamicmap>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("dynamicmaps");

                entity.HasIndex(e => e.Uid, "UID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11)")
                    .HasColumnName("UID");

                entity.Property(e => e.BaseMap).HasColumnType("int(4)");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("ID");

                entity.Property(e => e.Claimed).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.EventType).HasColumnType("int(6) unsigned");

                entity.Property(e => e.Face).HasColumnType("int(11) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("'None'");

                entity.Property(e => e.Rank).HasColumnType("int(4) unsigned");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("UID");
            });

            modelBuilder.Entity<Furniture>(entity =>
            {
                entity.HasKey(e => e.No)
                    .HasName("PRIMARY");

                entity.ToTable("furniture");

                entity.Property(e => e.No)
                    .HasColumnType("int(11)")
                    .HasColumnName("no");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Npcid)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("npcid");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("uid");

                entity.Property(e => e.X)
                    .HasColumnType("int(11)")
                    .HasColumnName("x");

                entity.Property(e => e.Y)
                    .HasColumnType("int(11)")
                    .HasColumnName("y");
            });

            modelBuilder.Entity<Guild>(entity =>
            {
                entity.ToTable("guilds");

                entity.HasIndex(e => e.Id, "ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(4) unsigned zerofill")
                    .HasColumnName("ID");

                entity.Property(e => e.Bulletin)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'None'");

                entity.Property(e => e.Fund).HasColumnType("int(11)");

                entity.Property(e => e.GuildPoints).HasColumnType("int(255)");

                entity.Property(e => e.Gwpoints)
                    .HasColumnType("int(255)")
                    .HasColumnName("GWPoints");

                entity.Property(e => e.LeaderId)
                    .HasColumnType("int(4) unsigned")
                    .HasColumnName("LeaderID");

                entity.Property(e => e.LeaderName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("'None'");

                entity.Property(e => e.Members).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Wins).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Guildmember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PRIMARY");

                entity.ToTable("guildmembers");

                entity.HasIndex(e => e.MemberId, "MemberID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.MemberId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("MemberID");

                entity.Property(e => e.Donation).HasColumnType("int(11)");

                entity.Property(e => e.GuildId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("GuildID");

                entity.Property(e => e.Level)
                    .HasColumnType("int(4) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("'None'");

                entity.Property(e => e.Rank).HasColumnType("smallint(4) unsigned");
            });

            modelBuilder.Entity<Guildrelation>(entity =>
            {
                entity.ToTable("guildrelations");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Associatename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("associatename");

                entity.Property(e => e.Associateuid)
                    .HasColumnType("int(4) unsigned zerofill")
                    .HasColumnName("associateuid")
                    .HasDefaultValueSql("'0000'");

                entity.Property(e => e.Guilduid)
                    .HasColumnType("int(4) unsigned zerofill")
                    .HasColumnName("guilduid")
                    .HasDefaultValueSql("'0000'");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(1) unsigned zerofill")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Guildstatue>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("guildstatues");

                entity.Property(e => e.Uid)
                    .HasColumnType("bigint(2)")
                    .HasColumnName("uid");

                entity.Property(e => e.Action).HasColumnType("int(11)");

                entity.Property(e => e.Armor).HasColumnType("mediumint(8)");

                entity.Property(e => e.ArmorColor).HasColumnType("int(11)");

                entity.Property(e => e.CurHp)
                    .HasColumnType("int(11)")
                    .HasColumnName("CurHP");

                entity.Property(e => e.Direction).HasColumnType("int(11)");

                entity.Property(e => e.Frame).HasColumnType("int(11)");

                entity.Property(e => e.Garment).HasColumnType("mediumint(8)");

                entity.Property(e => e.GuildId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GuildID");

                entity.Property(e => e.GuildRank).HasColumnType("int(11)");

                entity.Property(e => e.Hair).HasColumnType("int(11)");

                entity.Property(e => e.Headgear).HasColumnType("mediumint(8)");

                entity.Property(e => e.HeadgearColor).HasColumnType("int(11)");

                entity.Property(e => e.LeftHand).HasColumnType("mediumint(8)");

                entity.Property(e => e.LeftHandColor).HasColumnType("int(11)");

                entity.Property(e => e.Map).HasColumnType("int(11)");

                entity.Property(e => e.MaxHp)
                    .HasColumnType("int(11)")
                    .HasColumnName("MaxHP");

                entity.Property(e => e.Mesh).HasColumnType("mediumint(8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Necklace).HasColumnType("mediumint(8)");

                entity.Property(e => e.RightHand).HasColumnType("mediumint(8)");

                entity.Property(e => e.Ring).HasColumnType("mediumint(8)");

                entity.Property(e => e.X).HasColumnType("int(11)");

                entity.Property(e => e.Y).HasColumnType("int(11)");
            });

            modelBuilder.Entity<GwVisitor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("gw_visitors");

                entity.Property(e => e.Count).HasColumnType("int(11)");

                entity.Property(e => e.GuildName).HasMaxLength(255);
            });

            modelBuilder.Entity<Itemadd>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PRIMARY");

                entity.ToTable("itemadd");

                entity.Property(e => e.UniqueId)
                    .HasColumnType("int(10)")
                    .HasColumnName("UniqueID");

                entity.Property(e => e.Accuracy).HasColumnType("int(4)");

                entity.Property(e => e.BaseId)
                    .HasColumnType("int(10)")
                    .HasColumnName("BaseID");

                entity.Property(e => e.Defense).HasColumnType("int(4)");

                entity.Property(e => e.Dodge).HasColumnType("tinyint(3)");

                entity.Property(e => e.Health).HasColumnType("int(4)");

                entity.Property(e => e.MagicDamage).HasColumnType("int(4)");

                entity.Property(e => e.MagicDefense).HasColumnType("int(4)");

                entity.Property(e => e.MaximumDamage).HasColumnType("int(10)");

                entity.Property(e => e.MinimumDamage).HasColumnType("int(10)");

                entity.Property(e => e.Plus).HasColumnType("tinyint(3)");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("logs");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnType("varchar(5000)")
                    .HasColumnName("data");
            });

            modelBuilder.Entity<LogPayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("log_payments");

                entity.Property(e => e.Date)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("date");

                entity.Property(e => e.Log)
                    .HasColumnType("varchar(5000)")
                    .HasColumnName("log");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Npc>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("npcs");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("UID");

                entity.Property(e => e.Begin).HasColumnType("smallint(4)");

                entity.Property(e => e.Dmap)
                    .HasColumnType("int(4)")
                    .HasColumnName("DMap");

                entity.Property(e => e.Duration).HasColumnType("smallint(4)");

                entity.Property(e => e.Dx)
                    .HasColumnType("int(4)")
                    .HasColumnName("DX");

                entity.Property(e => e.Dy)
                    .HasColumnType("int(4)")
                    .HasColumnName("DY");

                entity.Property(e => e.End).HasColumnType("smallint(4)");

                entity.Property(e => e.Face)
                    .HasColumnType("smallint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Flags)
                    .HasColumnType("smallint(4) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Map).HasColumnType("int(4)");

                entity.Property(e => e.Month).HasColumnType("smallint(4)");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnType("int(4) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.X).HasColumnType("int(4)");

                entity.Property(e => e.Y).HasColumnType("int(4)");
            });

            modelBuilder.Entity<NpcsCopy1>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("npcs_copy1");

                entity.Property(e => e.Uid)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("UID");

                entity.Property(e => e.Begin).HasColumnType("smallint(4)");

                entity.Property(e => e.Dmap)
                    .HasColumnType("int(4)")
                    .HasColumnName("DMap");

                entity.Property(e => e.Duration).HasColumnType("smallint(4)");

                entity.Property(e => e.Dx)
                    .HasColumnType("int(4)")
                    .HasColumnName("DX");

                entity.Property(e => e.Dy)
                    .HasColumnType("int(4)")
                    .HasColumnName("DY");

                entity.Property(e => e.End).HasColumnType("smallint(4)");

                entity.Property(e => e.Face)
                    .HasColumnType("smallint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Flags)
                    .HasColumnType("smallint(4) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Map).HasColumnType("int(4)");

                entity.Property(e => e.Month).HasColumnType("smallint(4)");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnType("int(4) unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.X).HasColumnType("int(4)");

                entity.Property(e => e.Y).HasColumnType("int(4)");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.TxnId)
                    .HasName("PRIMARY");

                entity.ToTable("payments");

                entity.Property(e => e.TxnId)
                    .HasMaxLength(255)
                    .HasColumnName("txn_id");

                entity.Property(e => e.Claimed)
                    .HasColumnType("int(255)")
                    .HasColumnName("claimed")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Date).ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .HasColumnName("item_name");

                entity.Property(e => e.ItemNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("item_number");

                entity.Property(e => e.McGross)
                    .HasMaxLength(255)
                    .HasColumnName("mc_gross");

                entity.Property(e => e.PayerId)
                    .HasMaxLength(255)
                    .HasColumnName("payer_id");

                entity.Property(e => e.PaymentDate)
                    .HasMaxLength(255)
                    .HasColumnName("payment_date");

                entity.Property(e => e.PaymentGross)
                    .HasMaxLength(255)
                    .HasColumnName("payment_gross");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(255)
                    .HasColumnName("payment_status");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Portal>(entity =>
            {
                entity.ToTable("portals");

                entity.HasIndex(e => e.Id, "ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DestinationMapId)
                    .HasColumnType("int(4) unsigned zerofill")
                    .HasColumnName("DestinationMapID")
                    .HasDefaultValueSql("'0000'");

                entity.Property(e => e.DestinationX)
                    .HasColumnType("int(4) unsigned zerofill")
                    .HasDefaultValueSql("'0000'");

                entity.Property(e => e.DestinationY)
                    .HasColumnType("int(4) unsigned zerofill")
                    .HasDefaultValueSql("'0000'");

                entity.Property(e => e.PortalMapId)
                    .HasColumnType("int(4) unsigned zerofill")
                    .HasColumnName("PortalMapID")
                    .HasDefaultValueSql("'0000'");

                entity.Property(e => e.PortalX)
                    .HasColumnType("int(4) unsigned zerofill")
                    .HasDefaultValueSql("'0000'");

                entity.Property(e => e.PortalY)
                    .HasColumnType("int(4) unsigned zerofill")
                    .HasDefaultValueSql("'0000'");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("skills");

                entity.Property(e => e.Exp).HasColumnType("double(11,2)");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Level).HasColumnType("int(11)");

                entity.Property(e => e.Owner).HasColumnType("int(11)");

                entity.Property(e => e.PreviousLevel).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Stat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stats");

                entity.Property(e => e.DragonBalls).HasColumnType("bigint(255)");

                entity.Property(e => e.ElitesDropped).HasColumnType("bigint(255)");

                entity.Property(e => e.LastCcwin)
                    .HasMaxLength(255)
                    .HasColumnName("LastCCWin");

                entity.Property(e => e.LastGwwin)
                    .HasMaxLength(255)
                    .HasColumnName("LastGWWin");

                entity.Property(e => e.LastTcwin)
                    .HasMaxLength(255)
                    .HasColumnName("LastTCWin");

                entity.Property(e => e.MaxOnline).HasColumnType("bigint(255)");

                entity.Property(e => e.Meteors).HasColumnType("bigint(255)");

                entity.Property(e => e.MonstersGold).HasColumnType("bigint(255)");

                entity.Property(e => e.MonstersKilled).HasColumnType("bigint(255)");

                entity.Property(e => e.NormalGemsMined).HasColumnType("bigint(255)");

                entity.Property(e => e.PickedUpSilvers).HasColumnType("bigint(255)");

                entity.Property(e => e.RefinedGemsMined).HasColumnType("bigint(255)");

                entity.Property(e => e.RefsDropped).HasColumnType("bigint(255)");

                entity.Property(e => e.SuperGemsMined).HasColumnType("bigint(255)");

                entity.Property(e => e.SupersDropped).HasColumnType("bigint(255)");

                entity.Property(e => e.UniquesDropped).HasColumnType("bigint(255)");

                entity.Property(e => e._1socOpened)
                    .HasColumnType("bigint(255)")
                    .HasColumnName("1SocOpened");

                entity.Property(e => e._2socOpened)
                    .HasColumnType("bigint(255)")
                    .HasColumnName("2SocOpened");
            });

            modelBuilder.Entity<Top>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tops");

                entity.Property(e => e.GuildName).HasMaxLength(255);

                entity.Property(e => e.Level).HasColumnType("int(11)");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Param).HasColumnType("int(11)");

                entity.Property(e => e.Toptype)
                    .HasColumnType("int(11)")
                    .HasColumnName("toptype");

                entity.Property(e => e.Viplevel)
                    .HasColumnType("int(11)")
                    .HasColumnName("VIPLevel");
            });

            modelBuilder.Entity<VoteHistory>(entity =>
            {
                entity.HasKey(e => e.CharacterName)
                    .HasName("PRIMARY");

                entity.ToTable("vote_history");

                entity.HasIndex(e => e.CharacterName, "CharacterName_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CharacterName).HasMaxLength(45);

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Total).HasColumnType("int(11)");
            });

            modelBuilder.Entity<VotesAccount>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PRIMARY");

                entity.ToTable("votes_accounts");

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.Property(e => e.Claims)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastClaim).HasColumnType("datetime(6)");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Total)
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<VotesIp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("votes_ip");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("IP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
