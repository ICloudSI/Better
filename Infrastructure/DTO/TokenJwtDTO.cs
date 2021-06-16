using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.DTO.User;

namespace Infrastructure.DTO
{
    
    public class TokenJwtDTO
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
