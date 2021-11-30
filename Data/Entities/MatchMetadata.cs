namespace TftTracker.Data.Entities
{
    public class MatchMetadata
    {
        public int Id { get; set; }
        public string MatchId { get; set; }
        public Match Match { get; set; }
        public string DataVersion { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}