using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    public class MatchDTO
    {
        public ParticipantsDTO Participants { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BeginsAt { get; set; }
        public ParticipantDTO Winner { get; set; }
    }
}
