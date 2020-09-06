using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    public class SetWinnerModel
    {
        public Guid MatchId { get; set; }
        public Guid WinnerId { get; set; }
    }
}
