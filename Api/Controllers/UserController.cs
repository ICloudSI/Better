using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.DTO;
using Infrastructure.Excpections;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBetService _betService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IBetService betService, IMapper mapper)
        {
            _userService = userService;
            _betService = betService;
            _mapper = mapper;

        }

        [HttpGet("Browse")]
        public async Task<IActionResult> GetAll()
        {
            var usersToReturn = await _userService.BrowseAll();

            return Ok(usersToReturn);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetUserAsync(UserId));
        }

        [HttpGet("Bets")]
        [Authorize]
        public async Task<IActionResult> GetUserBets()
    {
            return Ok(await _betService.BrowseUserBets(UserId));
            
        }


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterModel registerModel)
        {
      
            var user = await _userService.RegisterAsync(registerModel);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {

            var token = await _userService.LoginAsync(loginModel);
            return Ok(token);
        }

        [HttpPut("Coins/Add")]
        public async Task<IActionResult> AddCoins(AddCoinsModel addCoinsModel)
        {

            return Ok(await _userService.AddCoins(addCoinsModel));

        }
        
    }
}