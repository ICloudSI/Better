using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public abstract class AbstractController<Ent, Dto>: ApiControllerBase where Ent : Entity where Dto : EntityDto
    {
        protected virtual EntityService<Ent, Dto> getService()
        {
            throw new NotImplementedException("Controller doesn't connect with service");
        }

        [HttpGet("Browse")]
        public async Task<IActionResult> BrowseAll()
        {
            return Ok(await getService().BrowseAll());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await getService().GetById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Dto dto)
        {
            dto.Id = id;
            return Ok(await getService().Update(dto));
        }
    }
}
