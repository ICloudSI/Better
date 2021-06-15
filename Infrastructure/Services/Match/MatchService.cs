using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Infrastructure.DTO;
using Infrastructure.Excpections;
using Infrastructure.Services.Algorithm;

namespace Infrastructure.Services
{
    public class MatchService: EntityService<Match, MatchDTO>, IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IAlgorithm _algorithm;

        public MatchService(IMatchRepository matchRepository, IParticipantRepository participantRepository, IMapper mapper, IAlgorithm algorithm): base(matchRepository, mapper)
        {
            _matchRepository = matchRepository;
            _participantRepository = participantRepository;
            _algorithm = algorithm;
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

        public async Task<MatchDTO> SetWinner(SetWinnerModel setWinner)
        {
            var matchFromRepo = await _matchRepository.GetById(setWinner.MatchId);
            if (matchFromRepo == null)
            {
                throw new AppException("Match doesn't exist.");
            }

            var winner = await _participantRepository.GetById(setWinner.WinnerId);

            if (matchFromRepo.Participants.Away != winner && matchFromRepo.Participants.Home != winner)
            {
                throw new AppException("Did not participate in the match.");
            }

            matchFromRepo.Status = MatchStatus.Finished;
            matchFromRepo.Winner = winner;

            await _matchRepository.Update(matchFromRepo);

            return _mapper.Map<MatchDTO>(matchFromRepo);
        }
    }
}
