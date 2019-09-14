using System;

namespace Better.Infrastructure.Dto
{
    public class BetDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MatchId { get; set; }
        public string Team { get; set; }
        public decimal Coins { get; set; }
    }
}