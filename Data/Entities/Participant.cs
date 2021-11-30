namespace TftTracker.Data.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        //TODO public Companian companian { get; set; }
        public int GoldLeft { get; set; }
        public int LastRound { get; set; }
        public int Level { get; set; }
        public MatchMetadata MatchMetadata { get; set; }
        public MatchInfo MatchInfo { get; set; }
        public int Placement { get; set; }
        public int PlayersEliminated { get; set; }
        public string Puuid { get; set; }
        public Summoner Summoner { get; set; }
        public float TimeEliminated { get; set; }
        public int TotalDamageToPlayers { get; set; }
        //TODO public ICollection<Trait> traits { get; set; }
        //TODO public ICollection<Unit> units { get; set; }
    }
}