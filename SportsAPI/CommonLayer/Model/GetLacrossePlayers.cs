namespace SportsAPI.CommonLayer.Model
{
    public class GetLacrossePlayersResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<GetLacrossePlayers> getLacrossePlayers { get; set; }
    }

    public class GetLacrossePlayers
    {
        public string player_name { get; set; } //PK
        public string team_name { get; set; }
        public int jersey_number { get; set; }
        public string height { get; set; }
        public int weight { get; set; }
        public char position { get; set; }
    }


}
