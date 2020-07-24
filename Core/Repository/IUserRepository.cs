using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Repository
{
    public interface IUserRepository: IRepository 
    {
        Task<User> GetFullUserAsync(Guid id);
        Task<User> GetFullUserAsync(string email);
        Task<User> GetSimpleUserAsync(Guid id);
        Task<User> GetSimpleUserAsync(string email);
        Task<IEnumerable<User>> BrowseAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);

    }
}
