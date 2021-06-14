using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Infrastructure.DTO;
using Infrastructure.Excpections;

namespace Infrastructure.Services
{
    public class MatchService: IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository matchRepository, IParticipantRepository participantRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _participantRepository = participantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatchDTO>> BrowseMatch()
        {
            var matches = await _matchRepository.GetAll();
            var matchesToReturn = _mapper.Map<IEnumerable<MatchDTO>>(matches);
            return matchesToReturn;
        }

        public async Task<MatchDTO> CreateMatch(CreateMatchModel createMatch)
        {
            var participantHome = await _participantRepository.GetById(createMatch.IdParticipantHome);
            if (participantHome == null)
            {
                throw new AppException("Home participant doesn't exist.");
            }

            var participantAway = await _participantRepository.GetById(createMatch.IdParticipantAway);
            if (participantAway == null)
            {
                throw new AppException("Away participant doesn't exist.");
            }

            var matchParticipant = new ParticipantsMatch(participantHome, participantAway);

            var match = new Match(new Guid(), matchParticipant,DateTime.Now, createMatch.BeginsAt);

            await _matchRepository.Insert(match);

            return _mapper.Map<MatchDTO>(match);
        }
    }
}
