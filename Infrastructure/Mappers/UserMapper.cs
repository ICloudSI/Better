using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Domain;
using Infrastructure.DTO;
using Infrastructure.DTO.User;

namespace Infrastructure.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<RegisterModel, User>();
        }
    }
}
