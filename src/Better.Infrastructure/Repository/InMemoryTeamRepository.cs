using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Better.Core.Domain;
using Better.Core.Repository;

namespace Better.Infrastructure.Repository
{
    public class InMemoryTeamRepository : ITeamRepository
    {
        private static readonly ISet<Team> _teams = new HashSet<Team>();

        public async Task<Team> GetAsync(Guid id)
            => await Task.FromResult(_teams.SingleOrDefault(team => team.Id == id));
            
        public async Task<Team> GetByNameAsync(string teamName)
            => await Task.FromResult(_teams.FirstOrDefault(team => team.TeamName == teamName));
        
        public async Task<IEnumerable<Team>> BrowseAsync()
        {
            var teams = _teams.AsEnumerable();
            return await Task.FromResult(teams);
        }
        public async Task AddAsync(Team team)
            => await Task.FromResult(_teams.Add(team));

        public async Task DeleteAsync(Team team)
        {
            _teams.Remove(team);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Team team)
        {
            await Task.CompletedTask;
        }

        public Task<Team> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}