using System;
using Better.Infrastructure.Dto;

namespace Better.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}