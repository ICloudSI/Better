using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Mappers
{
    public class BetMapper: Profile
    {
        public BetMapper()
        {
            CreateMap<Bet, BetDTO>().ForMember(dest => dest.MatchId,
                    opt => opt.
                        MapFrom(src => src.MatchConcerned.Id)).
                ForMember(dest => dest.OwnerId,
                    opt => opt.
                        MapFrom(src => src.Owner.Id));
        }
    }
}
