namespace SportsAPI.CommonLayer.Model
{
    public class GetLacrosseScheduleResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<GetLacrosseSchedule> getLacrosseSchedule { get; set; }
    }

    public class GetLacrosseSchedule
    {
        public int game_id { get; set; } //PK
        public DateTime date { get; set; }
        public string away_team { get; set; }
        public string home_team { get; set; }
    }
}
