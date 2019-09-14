using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Better.Infrastructure.Dto;

namespace Better.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetUserAsync(Guid id);
        Task<IEnumerable<UserDto>> BrowseAsync(); 
        Task RegisterAsync(Guid id, string email, string username, string password,string role = "user");
        Task<TokenDto> LoginAsync(string email, string password);
        
    }
}