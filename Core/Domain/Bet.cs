using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Bet:Entity
    {
        public Match MatchConcerned { get; set; }
        public decimal Value { get; set; }
        public Participant BetParticipant { get; set; }
        public User Owner { get; set; }
        public DateTime BetDate { get; set; }
    }
}
