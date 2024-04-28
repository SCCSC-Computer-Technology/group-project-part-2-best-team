using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SportsAPI.CommonLayer.Model;
using SportsAPI.ServiceLayer;
using System.Net.NetworkInformation;

namespace SportsAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SportsAPIController : ControllerBase
    {
        public readonly ISportsApiSL _sPortsApiRL;
        public readonly ILogger<SportsAPIController> _logger;

        public SportsAPIController(ISportsApiSL sPortsApiRL, ILogger<SportsAPIController> logger)
        {
            _sPortsApiRL = sPortsApiRL;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest request)
        {
            AddUserResponse response = new AddUserResponse();
            _logger.LogInformation($"AddUser API Calling in Controller...{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _sPortsApiRL.AddUser(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new {IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"AddUser API Error Occurred : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserByUsername(UpdateUserByUsernameRequest request)
        {
            UpdateUserByUsernameResponse response = new UpdateUserByUsernameResponse();
            _logger.LogInformation($"UpdateUserByUsername API Calling in Controller...{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _sPortsApiRL.UpdateUserByUsername(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"UpdateUserByUsername API Error Occurred : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            GetUserResponse response = new GetUserResponse();
            _logger.LogInformation($"GetUser API Calling in Controller...");

            try
            {
                response = await _sPortsApiRL.GetUser();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getUser });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"GetUser API Error Occurred : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getUser });
        }

        [HttpGet]
        public async Task<IActionResult> GetBowlingPlayers()
        {
            GetBowlingPlayersResponse response = new GetBowlingPlayersResponse();
            _logger.LogInformation($"GetBowlingPlayers API Calling in Controller...");

            try
            {
                response = await _sPortsApiRL.GetBowlingPlayers();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getBowlingPlayers });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"GetBowlingPlayers API Error Occurred : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getBowlingPlayers });
        }

        [HttpGet]
        public async Task<IActionResult> GetBowlingSchedule()
        {
            GetBowlingScheduleResponse response = new GetBowlingScheduleResponse();
            _logger.LogInformation($"GetBowlingSchedule API Calling in Controller...");

            try
            {
                response = await _sPortsApiRL.GetBowlingSchedule();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getBowlingSchedule });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"GetBowlingSchedule API Error Occurred : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getBowlingSchedule });
        }

        [HttpGet]
        public async Task<IActionResult> GetLacrossePlayers()
        {
            GetLacrossePlayersResponse response = new GetLacrossePlayersResponse();
            _logger.LogInformation($"GetLacrossePlayers API Calling in Controller...");

            try
            {
                response = await _sPortsApiRL.GetLacrossePlayers();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getLacrossePlayers });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"GetLacrossePlayers API Error Occurred : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getLacrossePlayers });
        }

        [HttpGet]
        public async Task<IActionResult> GetLacrosseSchedule()
        {
            GetLacrosseScheduleResponse response = new GetLacrosseScheduleResponse();
            _logger.LogInformation($"GetLacrosseSchedule API Calling in Controller...");

            try
            {
                response = await _sPortsApiRL.GetLacrosseSchedule();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getLacrosseSchedule });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"GetLacrosseSchedule API Error Occurred : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getLacrosseSchedule });
        }

        [HttpGet]
        public async Task<IActionResult> GetLacrosseTeams()
        {
            GetLacrosseTeamsResponse response = new GetLacrosseTeamsResponse();
            _logger.LogInformation($"GetLacrosseTeams API Calling in Controller...");

            try
            {
                response = await _sPortsApiRL.GetLacrosseTeams();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getLacrosseTeams });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"GetLacrosseTeams API Error Occurred : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getLacrosseTeams });
        }


    }
}
