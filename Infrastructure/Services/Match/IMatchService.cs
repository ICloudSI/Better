using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IMatchService: IService, IEntityService<Match, MatchDTO>
    {
        Task<MatchDTO> CreateMatch(CreateMatchModel createMatch);
        Task<MatchDTO> SetWinner(SetWinnerModel setWinner);
    }
}
