using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Infrastructure.Services
{
    public interface IEntityService<Ent, Dto > : IService where Ent : Entity
    {
        Task<IEnumerable<Dto>> BrowseAll();
        Task<Dto> GetById(Guid id);
    }
}
