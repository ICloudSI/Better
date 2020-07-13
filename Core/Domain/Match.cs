using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Match:Entity
    {
        private ISet<Bet> _bets = new HashSet<Bet>();

        public ParticipantsMatch Participants { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BeginsAt { get; set; }
        public Participant Winner { get; set; }
        public IEnumerable<Bet> Bets => _bets;

        protected Match()
        {
        }

        public Match(Guid id, ParticipantsMatch participants, DateTime createdAt, DateTime beginsAt)
        {
            Id = id;
            Participants = participants;
            CreatedAt = createdAt;
            BeginsAt = beginsAt;
        }
    }


}
