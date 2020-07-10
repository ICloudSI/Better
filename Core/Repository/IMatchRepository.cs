using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Repository
{
    public interface IMatchRepository
    {
        Task<Match> GetAsync(Guid id);
        Task<IEnumerable<Match>> BrowseAsync();
        Task AddAsync(Match match);
        Task UpdateAsync(Match match);
        Task DeleteAsync(Match match);
    }
}
