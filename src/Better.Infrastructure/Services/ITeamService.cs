using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Better.Infrastructure.Dto;

namespace Better.Infrastructure.Services
{
    public interface ITeamService : IService
    {
        Task<TeamDto> GetAsync(Guid id);
        Task<IEnumerable<TeamDto>> BrowseAsync();
        Task CreateTeamAsync(string team);
    }
}