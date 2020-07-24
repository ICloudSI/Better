using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Mappers
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, SimpleUserDTO>();
            CreateMap<User, FullUserWithBetsDTO>();
            CreateMap<RegisterModel, User>();
            CreateMap<Participant, ParticipantDTO>();
            CreateMap<ParticipantsMatch, ParticipantsDTO>();
            CreateMap<Match, MatchDTO>().ForMember(dest => dest.ValueBetOnHome,
                opt => opt.MapFrom(src =>
                    src.Bets.Where(home => home.BetParticipant == src.Participants.Home).Sum(sum => sum.Value))).
                ForMember(dest => dest.ValueBetOnAway,
                opt => opt.MapFrom(src =>
                    src.Bets.Where(away => away.BetParticipant == src.Participants.Away).Sum(sum => sum.Value)));

            CreateMap<Bet, BetDTO>().ForMember(dest => dest.MatchId,
                opt => opt.
                    MapFrom(src => src.MatchConcerned.Id)).
                ForMember(dest => dest.OwnerId,
                opt => opt.
                    MapFrom(src => src.Owner.Id));

        }
    }
}
