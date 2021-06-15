using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Infrastructure.DTO;
using Infrastructure.Excpections;
using Infrastructure.Services.Algorithm;

namespace Infrastructure.Services
{
    public class BetService: EntityService<Bet, BetDTO>, IBetService
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IUserRepository _userRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IAlgorithm _algorithm;

        public BetService(IBetRepository betRepository,
            IMatchRepository matchRepository,
            IUserRepository userRepository,
            IParticipantRepository participantRepository,
            IMapper mapper,
            IAlgorithm algorithm):base(betRepository, mapper)
        {
            _betRepository = betRepository;
            _matchRepository = matchRepository;
            _userRepository = userRepository;
            _participantRepository = participantRepository;
            _algorithm = algorithm;
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

        public async Task WithdrawPrize(Guid matchId)
        {
            var matchFromRepo = await _matchRepository.GetById(matchId);
            if (matchFromRepo != null && matchFromRepo.Status != MatchStatus.Finished)
            {
                throw new AppException("The match is not over");
            }

            var bets = await _betRepository.GetMatchBetsAsync(matchId);
            var multiplyPrize = _algorithm.MultiplierForWinner(bets, matchFromRepo.Winner);
            foreach (var bet in bets)
            {
                if (bet.BetParticipant == matchFromRepo.Winner && bet.Realized == false)
                {
                    var prize = Decimal.Round(bet.Value * multiplyPrize);
                    var user = bet.Owner;
                    user.Coins += prize;
                    await _userRepository.Update(user);
                }

                bet.Realized = true;
                await _betRepository.Update(bet);
            }
        }
    }
}