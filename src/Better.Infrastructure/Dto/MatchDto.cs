using System;

namespace Better.Infrastructure.Dto
{
    public class MatchDto
    {
        public Guid Id { get; set; }
        public string Team1 { get; set; }
        public Guid Team1Id { get; set; }
        public string Team2 { get; set; }
        public Guid Team2Id { get; set; }
        public DateTime StartTime { get; set; }
        public string Winner { get; set; }
        public Decimal BetOnTeam1 {get; set;}
        public Decimal BetOnTeam2 { get; set; }
    }
}