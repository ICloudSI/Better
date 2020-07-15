using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    public class CreateBetModel
    {
        public Guid MatchConcernedId { get; set; }
        public decimal Value { get; set; }
        public Guid BetParticipantId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
