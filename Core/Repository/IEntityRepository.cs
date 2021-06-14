using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IEntityRepository<T>: IRepository  where T : Entity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(Guid id);
        Task Save();
    }
}
