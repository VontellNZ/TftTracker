using System.ComponentModel.DataAnnotations;

namespace TftTracker.Data.Entities
{
    public class Summoner
    {
        public string accountId { get; set; }
        public int profileIconId { get; set; }

        [Display(Name = "Last Updated")]
        public long revisionDate { get; set; }

        [Display(Name = "Summoner Name")]
        public string name { get; set; }
        public string id { get; set; }
        public string puuid { get; set; }

        [Display(Name = "Summoner Level")]
        public long summonerLevel { get; set; }
    }
}