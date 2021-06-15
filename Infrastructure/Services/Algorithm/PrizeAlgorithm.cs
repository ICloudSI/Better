using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Domain;

namespace Infrastructure.Services.Algorithm
{
    public class PrizeAlgorithm : IAlgorithm
    {
        public decimal MultiplierForWinner(IEnumerable<Bet> bets, Participant winner)
        {
            var sumValue = bets.Sum(value => value.Value);
            var sumWinner = bets.Where(bets => bets.BetParticipant == winner).Sum(value => value.Value);

            return (sumValue - sumWinner) / sumWinner;
        }
    }
}
