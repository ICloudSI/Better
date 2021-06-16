using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public abstract class AbstractController<Ent, Dto>: ApiControllerBase where Ent : Entity
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
    }
}
