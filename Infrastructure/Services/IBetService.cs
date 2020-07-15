﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IBetService: IService
    {
        Task<IEnumerable<BetDTO>> BrowseAll();
        Task<IEnumerable<BetDTO>> BrowseMatchBets(Guid id);
        Task<BetDTO> CreateBet(CreateBetModel newBet);
    }
}
