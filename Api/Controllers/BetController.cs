using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BetController : AbstractController<Bet,BetDTO>
    {
        private readonly IBetService _betService;

        public BetController(IBetService betService)
        {
            _betService = betService;
        }

        protected override EntityService<Bet, BetDTO> getService()
        {
            return (EntityService<Bet, BetDTO>)_betService;
        }

        [HttpPut("{matchId}/Withdraw")]
        public async Task<IActionResult> WithdrawPrize(Guid matchId)
        {

            await _betService.WithdrawPrize(matchId);
            return Ok();

        }

    }
}
