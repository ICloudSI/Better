using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MatchRepository: IMatchRepository
    {
        private readonly BetterContext _dbContext;

        public MatchRepository(BetterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Match> GetAsync(Guid id)
            => await _dbContext.Matches.Include(matchBets => matchBets.Bets).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Match>> BrowseAsync()
            => await _dbContext.Matches.Include(matchBets => matchBets.Bets).ToListAsync();

        public async Task AddAsync(Match match)
        {
            {
                await _dbContext.Matches.AddAsync(match);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Match match)
        {
            _dbContext.Matches.Update(match);
            await _dbContext.SaveChangesAsync();
        }
  

        public async Task DeleteAsync(Match match)
        {
            _dbContext.Matches.Remove(match);
            await _dbContext.SaveChangesAsync();
        }
    }
}
