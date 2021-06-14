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
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(BetterContext context): base(context)
        {
        }


        public async Task<User> GetFullUserAsync(string email)
            => await table.Include(_context.GetIncludePaths(typeof(User)))
                .FirstOrDefaultAsync(user => user.Email == email);
    }
}
