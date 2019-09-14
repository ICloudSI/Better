using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Better.Core.Domain;
using Better.Core.Repository;
using Better.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Better.Infrastructure.Repository
{
    public class MatchRepository : IMatchRepository, ISqlRepository
    {
        private readonly BetterContext _context;

        public MatchRepository(BetterContext context)
        {
            _context = context;
        }
        public async Task<Match> GetAsync(Guid id)
            => await _context.Matches.Include(x => x.Bets).SingleOrDefaultAsync(x => x.Id == id);
          
        
        public async Task<IEnumerable<Match>> BrowseAsync()
            => await _context.Matches.Include(x => x.Bets).ToListAsync();

        public async Task AddAsync(Match match)
        {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Match match)
        {
            _context.Matches.Update(match);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Match match)
        {
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
        }

    }
}