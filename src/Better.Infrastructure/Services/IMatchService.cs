using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Better.Infrastructure.Dto;

namespace Better.Infrastructure.Services
{
    public interface IMatchService :IService
    {
        Task<MatchDto> GetAsync(Guid id);
        Task<MatchDetailsDto> GetDetailsAsync(Guid id);
        Task<IEnumerable<MatchDto>> BrowseAsync();
        Task CreateMatchAsync(Guid id, string team1, string team2, DateTime startTime);
        Task AddBetAsync(Guid id,Guid userId, string team, decimal coins);
        Task SetWinnerAsync(Guid id, string team);
        Task DeleteWithReturnAsync(Guid id);
        
    }
}