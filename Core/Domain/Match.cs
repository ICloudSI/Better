using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Match:Entity
    {
        public ParticipantsMatch Participants { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BeginsAt { get; set; }
        public Participant Winner { get; set; }

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
