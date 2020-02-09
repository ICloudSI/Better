using System;
using System.Threading.Tasks;
using Better.Infrastructure.Commands.Match;
using Better.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Better.Api.Controllers
{
    [Route("[controller]")]
    public class MatchController : ApiControllerBase
    {
        private readonly IMatchService _matchService;
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var matches = await _matchService.BrowseAsync();

            return Json(matches);
        }
        [HttpGet("{matchId}")]
        public async Task<IActionResult> Get(Guid matchId)
        {
            var matches = await _matchService.GetDetailsAsync(matchId);

            return Json(matches);
        }
        [HttpPut("AddBet/{matchId}")]
        [Authorize]
        public async Task<IActionResult> Put(Guid matchId,[FromBody] AddBet command)
        {
            await _matchService.AddBetAsync(matchId,UserId,command.Team,command.Coins);

            return NoContent();
        }

        [HttpPut("SetWinner/{matchId}")]
        public async Task<IActionResult> GetSetWinner(Guid matchId,[FromBody]SetWinner command)
        {
            await _matchService.SetWinnerAsync(matchId, command.Winner);
            return NoContent();
        }
        [HttpPut("CreateMatch")]
        public async Task<IActionResult> CreateMatchWinner([FromBody]CreateMatch command)
        {
            await _matchService.CreateMatchAsync(Guid.NewGuid(),command.Team1,command.Team2,command.StartTime);
            return NoContent();
        }
        
    }
}