using Core.Domain;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repository
{
    public abstract class EntityRepository<T> : IEntityRepository<T> where T : Entity
    {
        protected BetterContext _context = null;
        protected DbSet<T> table = null;

        public EntityRepository(BetterContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return table.Include(_context.GetIncludePaths(typeof(T))).ToList();
        }

        public async Task<T> GetById(Guid id)
        {
            return table.Include(_context.GetIncludePaths(typeof(T))).FirstOrDefault(entity => entity.Id == id);
        }

        public Task Insert(T obj)
        {
            table.Add(obj);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Update(T obj)
        {
            // table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Save()
        {
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
