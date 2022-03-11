using TftTracker.Data.Logic;

namespace TftTracker.Data
{
    public class TftSeeder
    {
        private readonly TftContext _context;
        private readonly IWebHostEnvironment _environment;

        public TftSeeder(TftContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public void Seed()
        {
            //Make sure DB exists
            _context.Database.EnsureCreated();

            //Create sample data
            _context.Summoners.SeedTable("Data/Dummy/summoners.json", _environment);
            _context.Matches.SeedTable("Data/Dummy/matches.json", _environment);
            _context.MatchInfo.SeedTable("Data/Dummy/matchInfo.json", _environment);
            // SeedTable(context.Matches, "Data/Dummy/matchMetadata.json", environment);
            // SeedTable(context.Matches, "Data/Dummy/participants.json", environment);

            _context.SaveChanges();
        }
    }
}