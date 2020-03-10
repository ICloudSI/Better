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
                cfg.CreateMap<Match, MatchDto>()
                .ForMember(dest => dest.Team1, opt => opt
                    .MapFrom(src => src.Team1.TeamName))
                .ForMember(dest => dest.Team1Id, opt => opt
                    .MapFrom(src => src.Team1.Id))
                .ForMember(dest => dest.Team2, opt => opt
                    .MapFrom(src => src.Team2.TeamName))
                .ForMember(dest => dest.Team2Id, opt => opt
                    .MapFrom(src => src.Team2.Id))
                .ForMember(dest => dest.BetOnTeam1, opt => opt
                    .MapFrom(src => src.Bets.Where(bet => bet.Team.Id == src.Team1.Id).Sum(bet=> bet.Coins)))
                .ForMember(dest => dest.BetOnTeam2, opt => opt
                    .MapFrom(src => src.Bets.Where(bet => bet.Team.Id== src.Team2.Id).Sum(bet=> bet.Coins)));
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Bet, BetDto>()
                    .ForMember(dest => dest.Team, opt => opt
                    .MapFrom(src => src.Team.Id));
                cfg.CreateMap<Match, MatchDetailsDto>();
                cfg.CreateMap<Team, TeamDto>();
            })
            .CreateMapper();

    }
}