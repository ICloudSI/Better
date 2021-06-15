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
        public bool Realized { get; set; }

        protected Bet()
        {

        }
        public Bet(Match matchConcerned, decimal value, Participant betParticipant, User owner, DateTime betDate)
        {
            MatchConcerned = matchConcerned;
            Value = value;
            BetParticipant = betParticipant;
            Owner = owner;
            BetDate = betDate;
            Realized = false;
        }
    }
}
