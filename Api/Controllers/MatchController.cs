using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.DTO;
using Infrastructure.Excpections;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchController : ApiControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IBetService _betService;
        private readonly IMapper _mapper;

        public MatchController(IMatchService matchService, IBetService betService, IMapper mapper)
        {
            _matchService = matchService;
            _betService = betService;
            _mapper = mapper;
        }

        [HttpGet("Browse")]
        public async Task<IActionResult> BrowseAll()
        {
            return Ok(await _matchService.BrowseMatch());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateMatch(CreateMatchModel createMatchModel)
        {
            try
            {
                return Ok(await _matchService.CreateMatch(createMatchModel));
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{matchId}/Bets/Browse")]
        public async Task<IActionResult> BrowseAll(Guid matchId)
        {
            return Ok(await _betService.BrowseMatchBets(matchId));
        }

        [HttpPost("Bet/Add")]
        [Authorize]
        public async Task<IActionResult> AddBet(CreateBetModel createBetModel)
        {
            createBetModel.OwnerId = UserId;
            try
            {
                return Ok(await _betService.CreateBet(createBetModel));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("{matchId}/SetWinner")]
        public async Task<IActionResult> SetWinner(SetWinnerModel setWinnerModel,Guid matchId)
        {
            setWinnerModel.MatchId = matchId;
            try
            {
                return Ok(await _matchService.SetWinner(setWinnerModel));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
