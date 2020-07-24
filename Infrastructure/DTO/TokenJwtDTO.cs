using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    
    public class TokenJwtDTO
    {
        public string Token { get; set; }
        public SimpleUserDTO User { get; set; }
    }
}
