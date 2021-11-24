using TftTracker.Models;

namespace TftTracker.Api
{
    public class MockSummonerProcessor : ISummonerProcessor
    {
        public Task<SummonerModel> LoadSummoner(string summonerName)
        {
            SummonerModel summoner = new SummonerModel();
            return Task.FromResult(summoner);
        }
    }
}