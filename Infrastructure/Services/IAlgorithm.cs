using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;

namespace Infrastructure.Services
{
    public interface IAlgorithm
    { 
        decimal MultiplierForWinner(IEnumerable<Bet> bets, Participant winner);
    }
}
