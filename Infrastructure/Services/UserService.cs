using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Infrastructure.DTO;


namespace Infrastructure.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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


        public async Task<UserDTO> RegisterAsync(User registeringUser, string password)
        {
            var user = await _userRepository.GetAsync(registeringUser.Email);
            if (user != null)
            {
                throw new Exception($"User with email: {registeringUser.Email} already exist");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            registeringUser.Id = Guid.NewGuid();
            registeringUser.Role = "user";
            registeringUser.PasswordHash = passwordHash;
            registeringUser.PasswordSalt = passwordSalt;

            _userRepository.AddAsync(registeringUser);

            var userToReturn = _mapper.Map<UserDTO>(registeringUser);
            return userToReturn;
        }

   

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
