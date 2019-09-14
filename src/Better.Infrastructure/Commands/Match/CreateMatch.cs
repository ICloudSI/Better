using System;

namespace Better.Infrastructure.Commands.Match
{
    public class CreateMatch
    {
        public string Team1 {get; set;}
        public string Team2 {get; set;}
        public DateTime StartTime {get; set;}
    }
}