using TftTracker.Data.Entities;

namespace TftTracker.Api
{
    public class MockSummonerProcessor : ISummonerProcessor
    {
        public Task<Summoner> LoadSummoner(string summonerName)
        {
            Summoner summoner = new Summoner();
            return Task.FromResult(summoner);
        }
    }
}