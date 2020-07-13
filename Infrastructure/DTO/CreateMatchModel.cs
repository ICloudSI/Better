using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    public class CreateMatchModel
    {
        public Guid IdParticipantHome { get; set; }
        public Guid IdParticipantAway { get; set; }
        public DateTime BeginsAt { get; set; }
    }
}
