using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IJwtHandler
    {
        TokenJwtDTO CreateToken(User user);
    }
}
