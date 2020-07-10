using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Participants
    {
        public Participant Home { get; set; }
        public Participant Away { get; set; }

        public Participants(Participant home, Participant away)
        {
            Home = home;
            Away = away;
        }
    }
}
