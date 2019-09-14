using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Better.Core.Domain;

namespace Better.Core.Repository
{
    public interface IMatchRepository : IRepository
    {
        Task<Match> GetAsync(Guid id);
        Task<IEnumerable<Match>> BrowseAsync();
        Task AddAsync(Match match);
        Task UpdateAsync(Match match);
        Task DeleteAsync(Match match);
    }
}