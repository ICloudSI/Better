using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.DTO;
using Infrastructure.Excpections;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }

        [HttpGet("Browse")]
        public async Task<IActionResult> BrowseAll()
        {
            return Ok(await _matchService.BrowseMatch());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateMatch([FromBody] CreateMatchModel createMatchModel)
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
    }
}
