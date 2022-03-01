using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public interface IEntityService<Ent, Dto > : IService where Ent : Entity where Dto: EntityDto
    {
        Task<IEnumerable<Dto>> BrowseAll();
        Task<Dto> GetById(Guid id);

        Task<Dto> Update(Dto obj);
    }
}
