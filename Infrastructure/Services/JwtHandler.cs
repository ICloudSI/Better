using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using Core.Domain;
using Infrastructure.DTO;
using Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    
    public class JwtHandler: IJwtHandler
    {
        private readonly AppSettings _appSettings;

        public JwtHandler(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public TokenJwtDTO CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier,user.Username)
                    
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return new TokenJwtDTO
            {
                Token = tokenString
            };
        }
    }
}
