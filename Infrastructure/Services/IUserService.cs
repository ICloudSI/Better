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
        Task<IEnumerable<User>> BrowseAsync();
        Task<UserDTO> RegisterAsync(User registeringUser, string password);
    }
}
