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

        public UserRepository(BetterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetFullUserAsync(Guid id)
            => await _dbContext.Users.Include(userBets => userBets.Bets).
                ThenInclude(x=>x.MatchConcerned).
                Include(userBets => userBets.Bets).
                ThenInclude(x => x.BetParticipant).
                SingleOrDefaultAsync(user => user.Id == id);
        public async Task<User> GetFullUserAsync(string email)
            => await _dbContext.Users.Include(userBets => userBets.Bets).
                ThenInclude(x => x.MatchConcerned).
                Include(userBets => userBets.Bets).
                ThenInclude(x => x.BetParticipant).
                SingleOrDefaultAsync(user => user.Email == email);

        public async Task<User> GetSimpleUserAsync(Guid id)
            => await _dbContext.Users.Include(userBets => userBets.Bets).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetSimpleUserAsync(string email)
            => await _dbContext.Users.Include(userBets => userBets.Bets).SingleOrDefaultAsync(x => x.Email == email);


        public async Task<IEnumerable<User>> BrowseAsync()
            => await _dbContext.Users.Include(userBets => userBets.Bets).ToListAsync();

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
