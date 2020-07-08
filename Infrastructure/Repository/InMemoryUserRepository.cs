using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class InMemoryUserRepository: IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>
        {
            new User(Guid.NewGuid(),"email@test.com","Janusz123","user","secret123","salt"),
            new User(Guid.NewGuid(),"email1@test.com","Janusz1234","user","secret123","salt"),
        };

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email));

        public async Task<IEnumerable<User>> BrowseAsync()
        {
            var users = _users.AsEnumerable();
            return await Task.FromResult(users);
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
