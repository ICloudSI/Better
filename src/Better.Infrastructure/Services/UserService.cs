using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Better.Core.Domain;
using Better.Core.Repository;
using Better.Infrastructure.Dto;

namespace Better.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        public UserService(IUserRepository userRepository,IJwtHandler jwtHandler ,IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
            _encrypter = encrypter;
        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            if (user == null)
            {
                throw new Exception($"User with id: '{id}' does not exist.");
            }

            return _mapper.Map<UserDto>(user);

        }
        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
        public async Task<TokenDto> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }
            
            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password != hash)
            {
                throw new Exception("Invalid credentials");
            }

            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            return new TokenDto
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.Role
            };
        }

        public async Task RegisterAsync(Guid id, string email, string username, string password,
            string role = "user")
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email:'{email}' already exist.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);

            user = new User(id, email, username, role, hash, salt);

            await _userRepository.AddAsync(user);
        }
    }
}