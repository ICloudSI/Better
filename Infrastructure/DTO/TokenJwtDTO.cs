using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    
    public class TokenJwtDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
