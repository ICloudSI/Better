using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;
using Infrastructure.DTO.User;

namespace Infrastructure.Services
{
    public interface IUserService: IService, IEntityService<User, UserDto>
    {
        Task<UserDto> AddCoins(AddCoinsModel addCoins);
        Task<UserDto> RegisterAsync(RegisterModel registeringUser);
        Task<TokenJwtDTO> LoginAsync(LoginModel loginData);
    }
}
