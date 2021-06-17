using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Mappers
{
    class ParticipantMapper : Profile
    {
        public ParticipantMapper()
        {
            CreateMap<Participant, ParticipantDTO>().ReverseMap(); ;
            CreateMap<ParticipantsMatch, ParticipantsDTO>();
        }
    }
}
