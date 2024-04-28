namespace SportsAPI.CommonLayer.Model
{
    public class GetLacrosseTeamsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<GetLacrosseTeams> getLacrosseTeams { get; set; }
    }

    public class GetLacrosseTeams
    {
        public string team_name { get; set; } //PK
        public int wins { get; set; }
        public int losses { get; set; }
        public decimal percent_wins { get; set; }
        public int goals_for { get; set; }
        public int goals_against { get; set; }
    }
}
