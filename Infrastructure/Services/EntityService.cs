using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public abstract class EntityService<Ent, Dto> : IEntityService<Ent, Dto> where Ent : Entity where Dto : EntityDto
    {
        protected readonly IEntityRepository<Ent> _entityRepository;
        protected readonly IMapper _mapper;

        protected EntityService(IEntityRepository<Ent> entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Dto>> BrowseAll()
        {
            return _mapper.Map<IEnumerable<Dto>>(await _entityRepository.GetAll());
        }

        public async Task<Dto> GetById(Guid id)
        {
            return _mapper.Map<Dto>(await _entityRepository.GetById(id));
        }

        public async Task<Dto> Update(Dto obj)
        {
            var entityFromDto = _mapper.Map<Ent>(obj);

            await _entityRepository.Update(entityFromDto);

            return _mapper.Map<Dto>(entityFromDto);
        }
    }
}
