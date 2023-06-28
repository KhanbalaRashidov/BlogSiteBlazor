using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Server.Controllers.Base
{
    //[Authorize(Policy = Policies.IsAdmin)]
    [ApiController]
    [Route("api/admin/[controller]")]
    public class AdminControllerBase : ControllerBase
    {
        protected const string Id = "{id}";
    }
}
