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
            var matches = await _matchRepository.BrowseAsync();
            var matchesToReturn = _mapper.Map<IEnumerable<MatchDTO>>(matches);
            return matchesToReturn;
        }

        public async Task<MatchDTO> CreateMatch(CreateMatchModel createMatch)
        {
            var participantHome = await _participantRepository.GetAsync(createMatch.IdParticipantHome);
            if (participantHome == null)
            {
                throw new AppException("Home participant doesn't exist.");
            }

            var participantAway = await _participantRepository.GetAsync(createMatch.IdParticipantAway);
            if (participantAway == null)
            {
                throw new AppException("Away participant doesn't exist.");
            }

            var matchParticipant = new ParticipantsMatch(participantHome, participantAway);

            var match = new Match(new Guid(), matchParticipant,DateTime.Now, createMatch.BeginsAt);

            await _matchRepository.AddAsync(match);

            return _mapper.Map<MatchDTO>(match);
        }
    }
}
