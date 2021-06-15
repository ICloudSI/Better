using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IParticipantService: IService, IEntityService<Participant,ParticipantDTO>
    {
        Task<ParticipantDTO> CreateParticipant(CreateParticipantModel participant);
    }
}
