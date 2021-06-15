using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;

namespace Infrastructure.Services.Algorithm
{
    public interface IAlgorithm: IService
    {
        decimal MultiplierForWinner(IEnumerable<Bet> bets, Participant winner);
    }
}
