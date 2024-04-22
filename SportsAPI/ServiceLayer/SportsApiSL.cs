using SportsAPI.CommonLayer.Model;
using SportsAPI.RepositoryLayer;

namespace SportsAPI.ServiceLayer
{
    public class SportsApiSL : ISportsApiSL
    {
        public readonly ISportsApiRL _sPortApiRL;
        public readonly ILogger<SportsApiSL> _logger;

        public SportsApiSL(ISportsApiRL sPortApiRL, ILogger<SportsApiSL> logger)
        {
            _sPortApiRL = sPortApiRL;
            _logger = logger;
        }

        //Get,Post,Put Methods for the User Table
        public async Task<AddUserResponse> AddUser(AddUserRequest request)
        {
            _logger.LogInformation("AddUser Method Calling in Service Layer");
            return await _sPortApiRL.AddUser(request);
        }
        public async Task<UpdateUserByUsernameResponse> UpdateUserByUsername(UpdateUserByUsernameRequest request)
        {
            _logger.LogInformation("UpdateUserByUsername Method Calling in Service Layer");
            return await _sPortApiRL.UpdateUserByUsername(request);
        }
        public async Task<GetUserResponse> GetUser()
        {
            _logger.LogInformation("GetUser Method Calling in Service Layer");
            return await _sPortApiRL.GetUser();
        }


        //Get Methods for Bowling Tables
        public async Task<GetBowlingPlayersResponse> GetBowlingPlayers()
        {
            _logger.LogInformation("GetBowlingPlayers Method Calling in Service Layer");
            return await _sPortApiRL.GetBowlingPlayers();
        }
        public async Task<GetBowlingScheduleResponse> GetBowlingSchedule()
        {
            _logger.LogInformation("GetBowlingSchedule Method Calling in Service Layer");
            return await _sPortApiRL.GetBowlingSchedule();
        }


        //Get Methods for Lacrosse Tables
        public async Task<GetLacrossePlayersResponse> GetLacrossePlayers()
        {
            _logger.LogInformation("GetLacrossePlayers Method Calling in Service Layer");
            return await _sPortApiRL.GetLacrossePlayers();
        }
        public async Task<GetLacrosseScheduleResponse> GetLacrosseSchedule()
        {
            _logger.LogInformation("GetLacrosseSchedule Method Calling in Service Layer");
            return await _sPortApiRL.GetLacrosseSchedule();
        }
        public async Task<GetLacrosseTeamsResponse> GetLacrosseTeams()
        {
            _logger.LogInformation("GetLacrosseTeams Method Calling in Service Layer");
            return await _sPortApiRL.GetLacrosseTeams();
        }
    }
}
