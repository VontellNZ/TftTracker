using TftTracker.Data;
using TftTracker.Data.Entities;

namespace TftTracker.Api
{
    public class MockSummonerProcessor : ISummonerProcessor
    {
        private const int PuuidLength = 78;

        private readonly TftContext _context;

        public MockSummonerProcessor(TftContext context)
        {
            _context = context;
        }


        public async Task<Summoner> LoadSummoner(string summonerName)
        {
            if (String.IsNullOrWhiteSpace(summonerName))
                return null;

            var summoners = _context.Summoners.ToList();
            var summoner = new Summoner{
                accountId = NextId(summoners, s => Int32.Parse(s.accountId)),
                profileIconId = new Random().Next(1, 9),
                revisionDate = DateTimeOffset.Now.ToUnixTimeSeconds(),
                name = summonerName,
                id = NextId(summoners, s => Int32.Parse(s.id)),
                puuid = RandomPuuid(),
                summonerLevel = new Random().Next(1, 999)
            };

            await _context.Summoners.AddAsync(summoner);
            await _context.SaveChangesAsync();

            return summoner;
        }

        private string NextId(List<Summoner> summoners, Func<Summoner, int> getId)
        {
            var maxId = summoners.Max(s => getId(s));
            maxId++;
            return maxId.ToString();
        }

        private string RandomPuuid()
        {
            const string numbers = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(numbers, PuuidLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());  
        }
    }
}