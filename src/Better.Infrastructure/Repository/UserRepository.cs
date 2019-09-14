using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Better.Core.Domain;
using Better.Core.Repository;
using Better.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Better.Infrastructure.Repository
{
    public class UserRepository : IUserRepository , ISqlRepository
    {
        private readonly BetterContext _context;



        public UserRepository(BetterContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(Guid id)
            => await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
            => await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        public async Task<IEnumerable<User>> BrowseAsync()
            => await _context.Users.ToListAsync();

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

        }

    }
}