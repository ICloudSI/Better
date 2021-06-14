using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Repository
{
    public interface IUserRepository: IEntityRepository<User>
    {
        Task<User> GetFullUserAsync(string email);
    }
}
