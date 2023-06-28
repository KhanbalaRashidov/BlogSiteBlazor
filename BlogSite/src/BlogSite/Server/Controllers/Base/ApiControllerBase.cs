using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Server.Controllers.Base
{
    public class ApiControllerBase : ControllerBase
    {
        protected const string Id = "{id}";
    }
}
