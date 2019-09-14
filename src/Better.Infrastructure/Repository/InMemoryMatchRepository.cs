using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Better.Core.Domain;
using Better.Core.Repository;

namespace Better.Infrastructure.Repository
{
    public class InMemoryMatchRepository : IMatchRepository
    {
        private static readonly ISet<Match> _matches = new HashSet<Match>
        {
            new Match(Guid.NewGuid(),"Astralis","Liquid",DateTime.UtcNow.AddHours(2)),
            new Match(Guid.NewGuid(),"NRG","Natus Vincere",DateTime.UtcNow.AddHours(3)),

        };

        public async Task<Match> GetAsync(Guid id)
            => await Task.FromResult(_matches.SingleOrDefault(x => x.Id == id));
        public async Task<IEnumerable<Match>> BrowseAsync()
        {
            var matches = _matches.AsEnumerable();
            return await Task.FromResult(matches);
        }
        public async Task AddAsync(Match match)
        {
            _matches.Add(match);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(Match match)
        {
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(Match match)
        {
            _matches.Remove(match);
            await Task.CompletedTask;
        }
    }
}