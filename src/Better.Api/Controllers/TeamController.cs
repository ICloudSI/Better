using System.Threading.Tasks;
using Better.Infrastructure.Commands.Team;
using Better.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Better.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ApiControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("Browse")]
        public async Task<IActionResult> BrowseAsync()
            => Ok(await _teamService.BrowseAsync());

        [HttpPost]
        public async Task<IActionResult> CreateTeamAsync(CreateTeam command)
        {
            await _teamService.CreateTeamAsync(command.Team);
            return Ok();
        }
        
    }
}