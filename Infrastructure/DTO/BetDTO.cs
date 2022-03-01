using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;

namespace Infrastructure.DTO
{
    public class BetDTO : EntityDto
    {
        public Guid MatchId { get; set; }
        public decimal Value { get; set; }
        public ParticipantDTO BetParticipant { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime BetDate { get; set; }
    }
}
