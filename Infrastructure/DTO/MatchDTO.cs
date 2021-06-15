using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    public class MatchDTO
    {
        public Guid Id { get; set; }
        public ParticipantsDTO Participants { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BeginsAt { get; set; }
        public ParticipantDTO Winner { get; set; }
        public double ValueBetOnHome { get; set; }
        public double ValueBetOnAway { get; set; }
        //public IEnumerable<BetDTO> Bets { get; set; }
    }
}
