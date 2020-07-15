using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public class ParticipantService:IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;

        public ParticipantService(IParticipantRepository participantRepository, IMapper mapper)
        {
            _participantRepository = participantRepository;
            _mapper = mapper;
        }

        public async Task<ParticipantDTO> CreateParticipant(CreateParticipantModel participant)
        {
            var newParticipant = new Participant(Guid.NewGuid(), participant.Name);
            await _participantRepository.AddAsync(newParticipant);

            return _mapper.Map<ParticipantDTO>(newParticipant);
        }

        public async Task<IEnumerable<ParticipantDTO>> BrowseAll()
        {
            var allParticipants = await _participantRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<ParticipantDTO>>(allParticipants);
        }
    }
}
