using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Better.Core.Domain;
using Better.Core.Repository;
using Better.Infrastructure.Dto;

namespace Better.Infrastructure.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository matchRepository, IUserRepository userRepository,
            IMapper mapper)
        {
            _matchRepository = matchRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<MatchDto> GetAsync(Guid id)
        {
            var match = await _matchRepository.GetAsync(id);
            if(match == null)
            {
                throw new Exception($"Match with id: '{id}' does not exist.");
            }

            return _mapper.Map<MatchDto>(match);
        }
        public async Task<MatchDetailsDto> GetDetailsAsync(Guid id)
        {
            var match = await _matchRepository.GetAsync(id);
            if(match == null)
            {
                throw new Exception($"Match with id: '{id}' does not exist.");
            }

            return _mapper.Map<MatchDetailsDto>(match);
        }

        public async Task<IEnumerable<MatchDto>> BrowseAsync()
        {
            var matches = await _matchRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<MatchDto>>(matches);
        }
        public async Task CreateMatchAsync(Guid id, string team1, string team2, DateTime startTime)
        {
            var match = Match.Create(id, team1, team2, startTime);
            await _matchRepository.AddAsync(match);
        }
        public async Task AddBetAsync(Guid id, Guid userId, string team, decimal coins)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new Exception($"User with id: '{userId}' does not exist.");
            }
            var match = await _matchRepository.GetAsync(id);
            if (match == null)
            {
                throw new Exception($"Match with id: '{id}' does not exist.");
            }

            match.AddBet(user, team, coins);
            await _userRepository.UpdateAsync(user);
            await _matchRepository.UpdateAsync(match);
        }
        public async Task DeleteWithReturnAsync(Guid id)
        {
            var match = await _matchRepository.GetAsync(id);
            if (match == null)
            {
                throw new Exception($"Match with id: '{id}' does not exist.");
            }

            var bets = match.Bets;
            foreach (var bet in bets)
            {
                var user = await _userRepository.GetAsync(bet.UserId);
                user.AddCoins(bet.Coins);
                await _userRepository.UpdateAsync(user);
            }

            await _matchRepository.DeleteAsync(match);
        }

        public async Task SetWinnerAsync(Guid id, string team)
        {
            var match = await _matchRepository.GetAsync(id);
            if (match == null)
            {
                throw new Exception($"Match with id: '{id}' does not exist.");
            }
            match.SetWinner(team);

            var bets = match.Bets;

            foreach(var bet in bets)
            {
                if(match.Winner.Equals(bet.Team))
                {
                    var user = await _userRepository.GetAsync(bet.UserId);
                    user.AddCoins(2*bet.Coins);
                    await _userRepository.UpdateAsync(user);
                }
            }
            
        }


    }
}