using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repository;
using Infrastructure.DTO;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParticipantController : ApiControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet("Browse")]
        public async Task<IActionResult> BrowseAll()
        {
            return Ok(await _participantService.BrowseAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateParticipant([FromBody] CreateParticipantModel participantModel)
        {
            return Ok(await _participantService.CreateParticipant(participantModel));
        }
    }
}
