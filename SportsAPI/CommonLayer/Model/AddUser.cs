using System.ComponentModel.DataAnnotations;

namespace SportsAPI.CommonLayer.Model
{
    public class AddUserRequest
    {
        [Required(ErrorMessage = "Username is a Mandatory Field")]
        public string username { get; set; } //PK
        public string password { get; set; }
        public string favorite_sport { get; set; }
        public string favorite_bowler { get; set; }
        public string favorite_lacrosse_player { get; set; }
        public string favorite_lacrosse_team { get; set; }
    }

    public class AddUserResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
