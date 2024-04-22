namespace SportsAPI.Common_Utility
{
    public class SqlQueries
    {
        public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile("SqlQueries.xml", true, true).Build();

        public static string AddUser { get { return _configuration["AddUser"]; } }
        public static string GetUser { get { return _configuration["GetUser"]; } }
        public static string UpdateUserByUsername { get { return _configuration["UpdateUserByUsername"]; } }

        public static string GetBowlingPlayers { get { return _configuration["GetBowlingPlayers"]; } }
        public static string GetBowlingSchedule { get { return _configuration["GetBowlingSchedule"]; } }

        public static string GetLacrossePlayers { get { return _configuration["GetLacrossePlayers"]; } }
        public static string GetLacrosseSchedule { get { return _configuration["GetLacrosseSchedule"]; } }
        public static string GetLacrosseTeams { get { return _configuration["GetLacrosseTeams"]; } }
    }
}
