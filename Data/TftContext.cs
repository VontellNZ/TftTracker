using Microsoft.EntityFrameworkCore;
using TftTracker.Data.Entities;

namespace TftTracker.Data
{
    public class TftContext : DbContext
    {
        public TftContext(DbContextOptions<TftContext> options) : base(options){}
        
        public DbSet<Summoner> Summoners { get; set; }
    }
}