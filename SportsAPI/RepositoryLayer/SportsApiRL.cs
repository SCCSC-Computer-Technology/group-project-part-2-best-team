using MySqlConnector;
using SportsAPI.Common_Utility;
using SportsAPI.CommonLayer.Model;
using System.ComponentModel;

namespace SportsAPI.RepositoryLayer
{
    public class SportsApiRL : ISportsApiRL
    {
        public readonly IConfiguration _configuration;
        public readonly ILogger<SportsApiRL> _logger;
        public readonly MySqlConnection _mySqlConnection;

        public SportsApiRL(IConfiguration configuration, ILogger<SportsApiRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _mySqlConnection = new MySqlConnection(_configuration["ConnectionStrings:MySqlDBString"]);
        }

        public async Task<AddUserResponse> AddUser(AddUserRequest request)
        {
            _logger.LogInformation("AddUser Method Calling in Repository Layer");
            AddUserResponse response = new AddUserResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.AddUser, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@username", request.username);
                    sqlCommand.Parameters.AddWithValue("@password", request.password);
                    sqlCommand.Parameters.AddWithValue("@favorite_sport", request.favorite_sport);
                    sqlCommand.Parameters.AddWithValue("@favorite_bowler", request.favorite_bowler);
                    sqlCommand.Parameters.AddWithValue("@favorite_lacrosse_player", request.favorite_lacrosse_player);
                    sqlCommand.Parameters.AddWithValue("@favorite_lacrosse_team", request.favorite_lacrosse_team);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Error Occurred : Query Not Executed");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"Error Occured at AddUser Repository Layer {ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }
        public async Task<UpdateUserByUsernameResponse> UpdateUserByUsername(UpdateUserByUsernameRequest request)
        {
            _logger.LogInformation("UpdateUserByUsername Method Calling in Repository Layer");
            UpdateUserByUsernameResponse response = new UpdateUserByUsernameResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.UpdateUserByUsername, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@username", request.username);
                    sqlCommand.Parameters.AddWithValue("@password", request.password);
                    sqlCommand.Parameters.AddWithValue("@favorite_sport", request.favorite_sport);
                    sqlCommand.Parameters.AddWithValue("@favorite_bowler", request.favorite_bowler);
                    sqlCommand.Parameters.AddWithValue("@favorite_lacrosse_player", request.favorite_lacrosse_player);
                    sqlCommand.Parameters.AddWithValue("@favorite_lacrosse_team", request.favorite_lacrosse_team);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Error Occurred : Query Not Executed");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"Error Occured at UpdateUserByUsername Repository Layer {ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }
        public async Task<GetUserResponse> GetUser()
        {
            GetUserResponse response = new GetUserResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.GetUser, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if(dataReader.HasRows)
                            {
                                response.getUser = new List<GetUser>();

                                while(await dataReader.ReadAsync())
                                {
                                    GetUser getData = new GetUser();
                                    getData.username = dataReader["username"] != DBNull.Value ? Convert.ToString(dataReader["username"]) : string.Empty;
                                    getData.password = dataReader["password"] != DBNull.Value ? Convert.ToString(dataReader["password"]) : string.Empty;
                                    getData.favorite_sport = dataReader["favorite_sport"] != DBNull.Value ? Convert.ToString(dataReader["favorite_sport"]) : string.Empty;
                                    getData.favorite_bowler = dataReader["favorite_bowler"] != DBNull.Value ? Convert.ToString(dataReader["favorite_bowler"]) : string.Empty;
                                    getData.favorite_lacrosse_player = dataReader["favorite_lacrosse_player"] != DBNull.Value ? Convert.ToString(dataReader["favorite_lacrosse_player"]) : string.Empty;
                                    getData.favorite_lacrosse_team = dataReader["favorite_lacrosse_team"] != DBNull.Value ? Convert.ToString(dataReader["favorite_lacrosse_team"]) : string.Empty;
                                    response.getUser.Add(getData);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Found / Database Empty";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetUsers Error Occured : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetUsers Error Occured : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<GetBowlingPlayersResponse> GetBowlingPlayers()
        {
            GetBowlingPlayersResponse response = new GetBowlingPlayersResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.GetBowlingPlayers, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.getBowlingPlayers = new List<GetBowlingPlayers>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetBowlingPlayers getData = new GetBowlingPlayers();
                                    getData.rank = dataReader["rank"] != DBNull.Value ? Convert.ToInt32(dataReader["rank"]) : 0;
                                    getData.points = dataReader["points"] != DBNull.Value ? Convert.ToDecimal(dataReader["points"]) : 0.00M;
                                    getData.player_name = dataReader["player_name"] != DBNull.Value ? Convert.ToString(dataReader["player_name"]) : string.Empty;
                                    getData.home = dataReader["home"] != DBNull.Value ? Convert.ToString(dataReader["home"]) : string.Empty;
                                    getData.earnings = dataReader["earnings"] != DBNull.Value ? Convert.ToDecimal(dataReader["earnings"]) : 0.00M;
                                    getData.events = dataReader["events"] != DBNull.Value ? Convert.ToInt32(dataReader["events"]) : 0;
                                    getData.average_score = dataReader["average_score"] != DBNull.Value ? Convert.ToDecimal(dataReader["average_score"]) : 0.00M;
                                    getData.games_played = dataReader["games_played"] != DBNull.Value ? Convert.ToInt32(dataReader["games_played"]) : 0;
                                    getData.titles = dataReader["titles"] != DBNull.Value ? Convert.ToInt32(dataReader["titles"]) : 0;
                                    getData.cra = dataReader["cra"] != DBNull.Value ? Convert.ToInt32(dataReader["cra"]) : 0;
                                    getData.mpa = dataReader["mpa"] != DBNull.Value ? Convert.ToInt32(dataReader["mpa"]) : 0;
                                    getData.cashes = dataReader["cashes"] != DBNull.Value ? Convert.ToInt32(dataReader["cashes"]) : 0;
                                    response.getBowlingPlayers.Add(getData);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Found / Database Empty";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetBowlingPlayers Error Occured : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetBowlingPlayers Error Occured : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }
        public async Task<GetBowlingScheduleResponse> GetBowlingSchedule()
        {
            GetBowlingScheduleResponse response = new GetBowlingScheduleResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.GetBowlingSchedule, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.getBowlingSchedule = new List<GetBowlingSchedule>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetBowlingSchedule getData = new GetBowlingSchedule();

                                    getData.id = dataReader["id"] != DBNull.Value ? Convert.ToInt32(dataReader["id"]) : 0;
                                    getData.start_date = dataReader["start_date"] != DBNull.Value ? Convert.ToDateTime(dataReader["start_date"]) : DateTime.MinValue;
                                    getData.end_date = dataReader["end_date"] != DBNull.Value ? Convert.ToDateTime(dataReader["end_date"]) : DateTime.MinValue;
                                    getData.title = dataReader["title"] != DBNull.Value ? Convert.ToString(dataReader["title"]) : string.Empty;
                                    getData.location = dataReader["location"] != DBNull.Value ? Convert.ToString(dataReader["location"]) : string.Empty;
                                    getData.city = dataReader["city"] != DBNull.Value ? Convert.ToString(dataReader["city"]) : string.Empty;
                                    getData.state_or_country = dataReader["state_or_country"] != DBNull.Value ? Convert.ToString(dataReader["state_or_country"]) : string.Empty;       

                                    response.getBowlingSchedule.Add(getData);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Found / Database Empty";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetBowlingSchedule Error Occured : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetBowlingSchedule Error Occured : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<GetLacrossePlayersResponse> GetLacrossePlayers()
        {
            GetLacrossePlayersResponse response = new GetLacrossePlayersResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.GetLacrossePlayers, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.getLacrossePlayers = new List<GetLacrossePlayers>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetLacrossePlayers getData = new GetLacrossePlayers();

                                    getData.player_name = dataReader["player_name"] != DBNull.Value ? Convert.ToString(dataReader["player_name"]) : string.Empty;
                                    getData.team_name = dataReader["team_name"] != DBNull.Value ? Convert.ToString(dataReader["team_name"]) : string.Empty;
                                    getData.jersey_number = dataReader["jersey_number"] != DBNull.Value ? Convert.ToInt32(dataReader["jersey_number"]) : 0;
                                    getData.height = dataReader["height"] != DBNull.Value ? Convert.ToString(dataReader["height"]) : string.Empty;
                                    getData.weight = dataReader["weight"] != DBNull.Value ? Convert.ToInt32(dataReader["weight"]) : 0;
                                    getData.position = dataReader["position"] != DBNull.Value ? Convert.ToChar(dataReader["position"]) : char.MinValue;

                                    response.getLacrossePlayers.Add(getData);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Found / Database Empty";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetLacrossePlayers Error Occured : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetLacrossePlayers Error Occured : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }
        public async Task<GetLacrosseScheduleResponse> GetLacrosseSchedule()
        {
            GetLacrosseScheduleResponse response = new GetLacrosseScheduleResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.GetLacrosseSchedule, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.getLacrosseSchedule = new List<GetLacrosseSchedule>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetLacrosseSchedule getData = new GetLacrosseSchedule();

                                    getData.game_id = dataReader["game_id"] != DBNull.Value ? Convert.ToInt32(dataReader["game_id"]) : 0;
                                    getData.date = dataReader["date"] != DBNull.Value ? Convert.ToDateTime(dataReader["date"]) : DateTime.MinValue;
                                    getData.away_team = dataReader["away_team"] != DBNull.Value ? Convert.ToString(dataReader["away_team"]) : string.Empty;
                                    getData.home_team = dataReader["home_team"] != DBNull.Value ? Convert.ToString(dataReader["home_team"]) : string.Empty;

                                    response.getLacrosseSchedule.Add(getData);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Found / Database Empty";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetLacrosseSchedule Error Occured : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetLacrosseSchedule Error Occured : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }
        public async Task<GetLacrosseTeamsResponse> GetLacrosseTeams()
        {
            GetLacrosseTeamsResponse response = new GetLacrosseTeamsResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.GetLacrosseTeams, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.getLacrosseTeams = new List<GetLacrosseTeams>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetLacrosseTeams getData = new GetLacrosseTeams();

                                    getData.team_name = dataReader["team_name"] != DBNull.Value ? Convert.ToString(dataReader["team_name"]) : string.Empty;
                                    getData.wins = dataReader["wins"] != DBNull.Value ? Convert.ToInt32(dataReader["wins"]) : 0;
                                    getData.losses = dataReader["losses"] != DBNull.Value ? Convert.ToInt32(dataReader["losses"]) : 0;
                                    getData.percent_wins = dataReader["percent_wins"] != DBNull.Value ? Convert.ToDecimal(dataReader["percent_wins"]) : 0.00M;
                                    getData.goals_for = dataReader["goals_for"] != DBNull.Value ? Convert.ToInt32(dataReader["goals_for"]) : 0;
                                    getData.goals_against = dataReader["goals_against"] != DBNull.Value ? Convert.ToInt32(dataReader["goals_against"]) : 0;

                                    response.getLacrosseTeams.Add(getData);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Found / Database Empty";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetLacrosseTeams Error Occured : Message : " + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetLacrosseTeams Error Occured : Message : " + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }



    }
}
