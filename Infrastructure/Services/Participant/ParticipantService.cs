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
    public class ParticipantService : EntityService<Participant, ParticipantDTO>, IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        public ParticipantService(IParticipantRepository participantRepository, IMapper mapper):base(participantRepository, mapper)
        {
            _participantRepository = participantRepository;
        }

        public async Task<ParticipantDTO> CreateParticipant(CreateParticipantModel participant)
        {
            var newParticipant = new Participant(Guid.NewGuid(), participant.Name);
            await _entityRepository.Insert(newParticipant);

            return _mapper.Map<ParticipantDTO>(newParticipant);
        }

        public async Task<IEnumerable<ParticipantDTO>> BrowseAll()
        {
            var allParticipants = await _entityRepository.GetAll();

            return _mapper.Map<IEnumerable<ParticipantDTO>>(allParticipants);
        }
    }
}
