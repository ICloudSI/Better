using System;
using System.Collections.Generic;
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
            CreateMap<User, UserDTO>();
            CreateMap<RegisterModel, User>();
            CreateMap<Participant, ParticipantDTO>();
            CreateMap<ParticipantsMatch, ParticipantsDTO>();
            CreateMap<Match, MatchDTO>();
            CreateMap<Bet, BetDTO>().ForMember(dest => dest.MatchId,
                opt => opt.
                    MapFrom(src => src.MatchConcerned.Id)).
                ForMember(dest => dest.OwnerId,
                opt => opt.
                    MapFrom(src => src.Owner.Id));

        }
    }
}
