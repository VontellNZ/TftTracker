using System.ComponentModel.DataAnnotations;

namespace TftTracker.Data.Entities
{
    public class Summoner
    {
        public string AccountId { get; set; }
        public int ProfileIconId { get; set; }

        [Display(Name = "Last Updated")]
        public long RevisionDate { get; set; }

        [Display(Name = "Summoner Name")]
        public string Name { get; set; }
        public string Id { get; set; }
        public string Puuid { get; set; }

        [Display(Name = "Summoner Level")]
        public long SummonerLevel { get; set; }
        public ICollection<Participant> Participations { get; set; }
    }
}