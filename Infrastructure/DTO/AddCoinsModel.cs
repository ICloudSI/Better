using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    public class AddCoinsModel
    {
        public Guid UserId { get; set; }   
        public decimal Value { get; set; }
    }
}
