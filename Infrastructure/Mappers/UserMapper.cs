using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, SimpleUserDTO>();
            CreateMap<User, FullUserWithBetsDTO>();
            CreateMap<RegisterModel, User>();
        }
    }
}
