using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Repository
{
    public interface IBetRepository: IRepository
    {
        Task<Bet> GetAsync(Guid id);
        Task<IEnumerable<Bet>> GetMatchBetsAsync(Guid matchId);
        Task<IEnumerable<Bet>> GetUserBetsAsync(Guid userId);
        Task<IEnumerable<Bet>> BrowseAsync();
        Task AddAsync(Bet bet);
        Task UpdateAsync(Bet bet);
        Task DeleteAsync(Bet bet);
    }
}
