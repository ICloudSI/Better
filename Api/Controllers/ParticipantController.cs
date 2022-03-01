using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;
using Infrastructure.DTO;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParticipantController : AbstractController<Participant, ParticipantDTO>
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        protected override EntityService<Participant, ParticipantDTO> getService()
        {
            return (EntityService<Participant, ParticipantDTO>)_participantService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParticipant(CreateParticipantModel participantModel)
        {
            return Ok(await _participantService.CreateParticipant(participantModel));
        }
    }
}
