using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Repository
{
    public interface IParticipantRepository: IRepository
    {

        Task<Participant> GetAsync(Guid id);
        Task<IEnumerable<Participant>> BrowseAsync();
        Task AddAsync(Participant participant);
        Task UpdateAsync(Participant participant);
        Task DeleteAsync(Participant participant);
    }
}
