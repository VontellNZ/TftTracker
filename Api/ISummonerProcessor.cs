using TftTracker.Data.Entities;

namespace TftTracker.Api
{
    interface ISummonerProcessor
    {
        Task<Summoner> LoadSummoner(string summonerName); 
    }
}