using System;

namespace Better.Infrastructure.Commands.Match
{
    public class AddBet
    {
        public Guid UserId { get; set; }
        public string Team { get; set; }
        public decimal Coins { get; set; }
    }
}