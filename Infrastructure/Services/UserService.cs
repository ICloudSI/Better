﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Infrastructure.DTO;
using Infrastructure.Excpections;


namespace Infrastructure.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public async Task<FullUserWithBetsDTO> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetFullUserAsync(id);

            return _mapper.Map<FullUserWithBetsDTO>(user);
        }

        public async Task<IEnumerable<SimpleUserDTO>> BrowseAsync()
        {
            var users = await _userRepository.BrowseAsync();
            var usersToReturn = _mapper.Map<IEnumerable<SimpleUserDTO>>(users);

            return usersToReturn;
        }

        public async Task<SimpleUserDTO> AddCoins(AddCoinsModel addCoins)
        {
            var user = await _userRepository.GetSimpleUserAsync(addCoins.UserId);
            if (user == null)
            {
                throw new AppException($"User with id {addCoins.UserId} doesn't exist");

            }

            if (addCoins.Value <= 0)
            {
                throw new AppException("Value can't be negative");
            }

            user.Coins += addCoins.Value;
            await _userRepository.UpdateAsync(user);
            return _mapper.Map<SimpleUserDTO>(user);
        }

        public async Task<TokenJwtDTO> LoginAsync(LoginModel loginData)
        {
            loginData.Email = loginData.Email.ToLower();
            if (string.IsNullOrEmpty(loginData.Email) || string.IsNullOrEmpty(loginData.Password))
            {
                throw new AppException("Email or password is incorrect");
            }

            var user = await _userRepository.GetSimpleUserAsync(loginData.Email);
            if (user == null)
            {
                throw new AppException($"User with email {loginData.Email} doesn't exist");
            }

            if (!VerifyPasswordHash(loginData.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new AppException("Email or password is incorrect");
            }

            var token = _jwtHandler.CreateToken(user);

            token.User = _mapper.Map<SimpleUserDTO>(user);

            return token;
        }

        public async Task<SimpleUserDTO> RegisterAsync(RegisterModel registeringUser)
        {
            var userToRegister = _mapper.Map<User>(registeringUser);
            userToRegister.Email = userToRegister.Email.ToLower();

            var user = await _userRepository.GetSimpleUserAsync(userToRegister.Email);
            if (user != null)
            {
                throw new AppException($"User with email: {registeringUser.Email} already exist");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(registeringUser.Password, out passwordHash, out passwordSalt);
            userToRegister.Id = Guid.NewGuid();
            userToRegister.Role = "user";
            userToRegister.CreatedAt = DateTime.Now;
            userToRegister.PasswordHash = passwordHash;
            userToRegister.PasswordSalt = passwordSalt;

           await _userRepository.AddAsync(userToRegister);

            var userToReturn = _mapper.Map<SimpleUserDTO>(userToRegister);
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
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
