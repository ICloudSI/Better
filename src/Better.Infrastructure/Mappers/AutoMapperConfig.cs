using System.Linq;
using AutoMapper;
using Better.Core.Domain;
using Better.Infrastructure.Dto;

namespace Better.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Match, MatchDto>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Bet, BetDto>();
                cfg.CreateMap<Match, MatchDetailsDto>();
            })
            .CreateMapper();

    }
}