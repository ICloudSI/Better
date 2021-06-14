using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Infrastructure.DTO;
using Infrastructure.Excpections;

namespace Infrastructure.Services
{
    public class BetService: IBetService
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IUserRepository _userRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;

        public BetService(IBetRepository betRepository, IMatchRepository matchRepository, IUserRepository userRepository, IParticipantRepository participantRepository, IMapper mapper)
        {
            _betRepository = betRepository;
            _matchRepository = matchRepository;
            _userRepository = userRepository;
            _participantRepository = participantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BetDTO>> BrowseAll()
        {
            var bets = await _betRepository.GetAll();
            return _mapper.Map<IEnumerable<BetDTO>>(bets);
        }
        public async Task<IEnumerable<BetDTO>> BrowseMatchBets(Guid id)
        {
            var bets = await _betRepository.GetMatchBetsAsync(id);
            return _mapper.Map<IEnumerable<BetDTO>>(bets);
        }
        public async Task<IEnumerable<BetDTO>> BrowseUserBets(Guid id)
        {
            var bets = await _betRepository.GetUserBetsAsync(id);
            return _mapper.Map<IEnumerable<BetDTO>>(bets);
        }


        public async Task<BetDTO> CreateBet(CreateBetModel newBet)
        {
            var match = await _matchRepository.GetById(newBet.MatchConcernedId);
            if (match == null)
            {
                throw new AppException($"Match with id: {newBet.MatchConcernedId} doesn't exits.");
            }

            if (match.Participants.Away.Id != newBet.BetParticipantId &&
                match.Participants.Home.Id != newBet.BetParticipantId)
            {
                throw new AppException($"The member with id: {newBet.BetParticipantId} does not participate in the match.");
            }

            var participants = await _participantRepository.GetById(newBet.BetParticipantId);

            var ownerUser = await _userRepository.GetById(newBet.OwnerId);
            if (newBet.Value <= 0)
            {
                throw new AppException($"The bet cannot be negative.");
            }
            if (ownerUser.Coins < newBet.Value)
            {
                throw new AppException($"The user does not have enough coins");
            }

            if ( DateTime.Now > match.BeginsAt)
            {
                throw new AppException($"Match has started already");
            }

            ownerUser.Coins -= newBet.Value;
            
            var bet = new Bet(match, newBet.Value,participants,ownerUser, DateTime.Now);

            await _userRepository.Update(ownerUser);
            await _betRepository.Insert(bet);

            return _mapper.Map<BetDTO>(bet);
        }
    }
}