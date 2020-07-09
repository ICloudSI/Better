using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.DTO;
using Infrastructure.Services;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }


        [HttpGet("Browse")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.BrowseAsync();

            var usersToReturn = _mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(usersToReturn);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel registerModel)
        {
            

            try
            {
                // create user
                var user = _userService.RegisterAsync(registerModel);
                return Ok(user);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {


            try
            {
                // create user
                var token = await _userService.LoginAsync(loginModel);
                return Ok(token);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}