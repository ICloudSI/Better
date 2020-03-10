using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Better.Core.Domain;

namespace Better.Core.Repository
{
    public interface ITeamRepository : IRepository
    {
        Task<Team> GetByIdAsync(Guid id);
        Task<Team> GetByNameAsync(string teamName);
        Task<IEnumerable<Team>> BrowseAsync();
        Task AddAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(Team team);
    }
}