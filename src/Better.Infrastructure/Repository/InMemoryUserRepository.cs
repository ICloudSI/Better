using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Better.Core.Domain;
using Better.Core.Repository;

namespace Better.Infrastructure.Repository
{
    public class InMemoryUserRepository : IUserRepository
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
        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }


    }
}