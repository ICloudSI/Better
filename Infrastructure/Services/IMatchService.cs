using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IMatchService: IService
    {
        Task<IEnumerable<MatchDTO>> BrowseMatch();
        Task<MatchDTO> CreateMatch(CreateMatchModel createMatch);
        Task<MatchDTO> SetWinner(SetWinnerModel setWinner);
    }
}
