using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly BetterContext _dbContext;


        public async Task<User> GetAsync(Guid id)
            => await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
            => await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);


        public async Task<IEnumerable<User>> BrowseAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
