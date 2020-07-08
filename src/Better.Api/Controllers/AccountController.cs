using System;
using System.Threading.Tasks;
using Better.Infrastructure.Commands.Users;
using Better.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Better.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
            => Ok(await _userService.GetUserAsync(UserId));

        [HttpGet("Browse")]
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            var users= await _userService.BrowseAsync();

            return Ok(users);
        }
        [HttpPost("register")]
        public async Task <IActionResult> Post(Register command)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email,command.Username,command.Password);

            return Created("/account", null);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Post(Login command)
            => Ok(await _userService.LoginAsync(command.Email, command.Password));
    }
}