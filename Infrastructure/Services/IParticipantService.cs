using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IParticipantService:IService
    {
        Task<ParticipantDTO> CreateParticipant(CreateParticipantModel participant);
        Task<IEnumerable<ParticipantDTO>> BrowseAll();
    }
}
