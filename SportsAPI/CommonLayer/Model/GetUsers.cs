namespace SportsAPI.CommonLayer.Model
{
    public class GetUserResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<GetUser> getUser { get; set; }
    }

    public class GetUser
    {
        public string username { get; set; } //PK
        public string password { get; set; }
        public string favorite_sport { get; set; }
        public string favorite_bowler { get; set; }
        public string favorite_lacrosse_player { get; set; }
        public string favorite_lacrosse_team { get; set; }
    }
}
