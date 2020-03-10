using System;
using Microsoft.AspNetCore.Mvc;

namespace Better.Api.Controllers
{
    [Route("[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) :
            Guid.Empty;

    }
}
