namespace SportsAPI.CommonLayer.Model
{
    public class GetBowlingScheduleResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<GetBowlingSchedule> getBowlingSchedule { get; set; }
    }

    public class GetBowlingSchedule
    {
        public int id { get; set; } //PK
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public string city { get; set; }
        public string state_or_country { get; set; }
    }
}
