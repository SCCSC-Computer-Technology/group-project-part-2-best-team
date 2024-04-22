namespace SportsAPI.CommonLayer.Model
{
    public class GetBowlingPlayersResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<GetBowlingPlayers> getBowlingPlayers { get; set; }
    }

    public class GetBowlingPlayers
    {
        public int rank { get; set; }
        public decimal points { get; set; }
        public string player_name { get; set; } //PK
        public string home { get; set; }
        public decimal earnings { get; set; }
        public int events { get; set; }
        public decimal average_score { get; set; }
        public int games_played { get; set; }
        public int titles { get; set; }
        public int cra { get; set; }
        public int mpa { get; set; }
        public int cashes { get; set; }
    }
}
