using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;

namespace Infrastructure.Services
{
    class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            return user;
        }

        public async Task<IEnumerable<User>> BrowseAsync()
        {
            var users = await _userRepository.BrowseAsync();
            return users;
        }
    }
}
