using System;
using System.Collections.Generic;

namespace Better.Infrastructure.Dto
{
    public class MatchDetailsDto
    {
        public Guid Id { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public DateTime StartTime { get; set; }
        public string Winner { get; set; }
        public IEnumerable<BetDto> Bets {get; set;}
    }
}