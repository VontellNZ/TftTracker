using TftTracker.Data.Entities;

namespace TftTracker.Api
{
    public interface ISummonerProcessor
    {
        Task<Summoner> LoadSummoner(string summonerName); 
    }
}