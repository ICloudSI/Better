using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class ParticipantsMatch : Entity
    {
        public Participant Home { get; set; }
        public Participant Away { get; set; }

        protected ParticipantsMatch()
        {}
        public ParticipantsMatch(Participant home, Participant away)
        {
            Home = home;
            Away = away;
        }
    }
}
