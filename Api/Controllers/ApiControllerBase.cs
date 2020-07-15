using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse((User.Identity as ClaimsIdentity).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value) :
            Guid.Empty;
    }
}
