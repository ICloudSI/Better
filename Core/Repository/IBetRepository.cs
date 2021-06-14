using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Repository
{
    public interface IBetRepository : IEntityRepository<Bet>
    {
        Task<IEnumerable<Bet>> GetMatchBetsAsync(Guid matchId);
        Task<IEnumerable<Bet>> GetUserBetsAsync(Guid userId);

    }
}
