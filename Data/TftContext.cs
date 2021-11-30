using Microsoft.EntityFrameworkCore;
using TftTracker.Data.Entities;

namespace TftTracker.Data
{
    public class TftContext : DbContext
    {
        public TftContext(DbContextOptions<TftContext> options) : base(options){}
        
        public DbSet<Summoner> Summoners { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchMetadata> MatchMetadata { get; set; }
        public DbSet<MatchInfo> MatchInfo { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
            .HasOne(m => m.Metadata)
            .WithOne(m => m.Match)
            .HasForeignKey<MatchMetadata>(m => m.MatchId);
            
            modelBuilder.Entity<Match>()
            .HasOne(m => m.Info)
            .WithOne(i => i.Match)
            .HasForeignKey<MatchInfo>(i => i.MatchId);

            modelBuilder.Entity<MatchInfo>()
            .HasMany(i => i.Participants)
            .WithOne(p => p.MatchInfo);

            modelBuilder.Entity<MatchMetadata>()
            .HasMany(m => m.Participants)
            .WithOne(p => p.MatchMetadata);

            modelBuilder.Entity<Summoner>()
            .HasMany(s => s.Participations)
            .WithOne(p => p.Summoner);
        }
    }
}