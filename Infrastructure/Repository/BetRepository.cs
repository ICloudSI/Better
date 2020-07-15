using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BetRepository:IBetRepository
    {
        private readonly BetterContext _dbContext;

        public BetRepository(BetterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Bet> GetAsync(Guid id)
            => await _dbContext.Bets.Include(ownerUser=>ownerUser.Owner).
                Include(match => match.MatchConcerned).
                Include(participant => participant.BetParticipant).
                FirstOrDefaultAsync(bet => bet.Id == id);

        public async Task<IEnumerable<Bet>> GetMatchBetsAsync(Guid matchId)
            => await _dbContext.Bets.Include(ownerUser => ownerUser.Owner).
                Include(match => match.MatchConcerned).
                Include(participant => participant.BetParticipant).
                Where(bet => bet.MatchConcerned.Id == matchId).ToListAsync();

        public async Task<IEnumerable<Bet>> BrowseAsync()
            => await _dbContext.Bets.Include(ownerUser => ownerUser.Owner).
                Include(match => match.MatchConcerned).
                Include(participant => participant.BetParticipant).
                ToListAsync();

        public async Task AddAsync(Bet bet)
        {
            {
                await _dbContext.Bets.AddAsync(bet);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Bet bet)
        {
            _dbContext.Bets.Update(bet);
            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteAsync(Bet bet)
        {
            _dbContext.Bets.Remove(bet);
            await _dbContext.SaveChangesAsync();
        }
    }
}

