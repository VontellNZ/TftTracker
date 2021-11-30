namespace TftTracker.Data.Entities
{
    public class Match
    {
        public string MatchId { get; set; }
        public MatchMetadata Metadata { get; set; }
        public MatchInfo Info { get; set; }
    }
}