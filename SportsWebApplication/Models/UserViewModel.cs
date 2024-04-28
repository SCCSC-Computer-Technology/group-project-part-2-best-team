using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportsWebApplication.Models
{
    public class UserViewModel
    {
        [DisplayName("User Name")]
        public string username { get; set; } //PK

        [DisplayName("Password")]
        public string password { get; set; }

        [DisplayName("Favorite Sport")]
        public string favorite_sport { get; set; }

        [DisplayName("Favorite Bowler")]
        public string favorite_bowler { get; set; }

        [DisplayName("Favorite Lacrosse Player")]
        public string favorite_lacrosse_player { get; set; }

        [DisplayName("Favorite Lacrosse Team")]
        public string favorite_lacrosse_team { get; set; }
    }
}
