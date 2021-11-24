using TftTracker.Models;

namespace TftTracker.Api
{
    interface ISummonerProcessor
    {
        Task<SummonerModel> LoadSummoner(string summonerName); 
    }
}