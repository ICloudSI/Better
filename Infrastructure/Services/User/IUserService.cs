﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IUserService: IService, IEntityService<User, SimpleUserDTO>
    {
        Task<FullUserWithBetsDTO> GetUserAsync(Guid id);
        Task<SimpleUserDTO> AddCoins(AddCoinsModel addCoins);
        Task<SimpleUserDTO> RegisterAsync(RegisterModel registeringUser);
        Task<TokenJwtDTO> LoginAsync(LoginModel loginData);
    }
}
