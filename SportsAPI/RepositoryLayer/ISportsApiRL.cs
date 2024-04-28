using SportsAPI.CommonLayer.Model;

namespace SportsAPI.RepositoryLayer
{
    public interface ISportsApiRL
    {
        public Task<AddUserResponse> AddUser(AddUserRequest request);
        public Task<UpdateUserByUsernameResponse> UpdateUserByUsername(UpdateUserByUsernameRequest request);
        public Task<GetUserResponse> GetUser();

        public Task<GetBowlingPlayersResponse> GetBowlingPlayers();
        public Task<GetBowlingScheduleResponse> GetBowlingSchedule();

        public Task<GetLacrossePlayersResponse> GetLacrossePlayers();
        public Task<GetLacrosseScheduleResponse> GetLacrosseSchedule();
        public Task<GetLacrosseTeamsResponse> GetLacrosseTeams();
    }
}
