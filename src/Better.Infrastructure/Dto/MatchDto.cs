using System;

namespace Better.Infrastructure.Dto
{
    public class MatchDto
    {
        public Guid Id { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public DateTime StartTime { get; set; }
        public string Winner { get; set; }
    }
}