using System;
using System.Threading.Tasks;
using TftTracker.Data.Entities;

namespace TftTracker.Api
{
    public class SummonerProcessor : ISummonerProcessor
    {
        public async Task<Summoner> LoadSummoner(string summonerName)
        {
            string url = $"oc1.api.riotgames.com/tft/summoner/v1/summoners/by-name/{summonerName}"; //Will need logic for grabbing the region
            using (HttpClient httpClient = new HttpClient())
            using (HttpResponseMessage response = await httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Summoner summoner = await response.Content.ReadAsAsync<Summoner>();

                    return summoner;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //Other endpoints for loading summoner can overload LoadSummoner() if/when I implement them
    }
}