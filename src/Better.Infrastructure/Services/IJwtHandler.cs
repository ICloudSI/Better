using System;
using Better.Infrastructure.Dto;

namespace Better.Infrastructure.Services
{
    public interface IJwtHandler
    {
        TokenDto CreateToken(Guid userId);
    }
}