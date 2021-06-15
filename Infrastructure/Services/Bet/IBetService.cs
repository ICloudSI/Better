using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IBetService: IService, IEntityService<Bet, BetDTO>
    {
        Task<IEnumerable<BetDTO>> BrowseMatchBets(Guid id);
        Task<IEnumerable<BetDTO>> BrowseUserBets(Guid id);
        Task<BetDTO> CreateBet(CreateBetModel newBet);
        Task WithdrawPrize(Guid matchId);
    }
}
