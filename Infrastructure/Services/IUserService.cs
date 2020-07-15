using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IUserService: IService
    {
        Task<UserDTO> GetUserAsync(Guid id);
        Task<IEnumerable<UserDTO>> BrowseAsync();
        Task<UserDTO> AddCoins(AddCoinsModel addCoins);
        Task<UserDTO> RegisterAsync(RegisterModel registeringUser);
        Task<TokenJwtDTO> LoginAsync(LoginModel loginData);
    }
}
