using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Conferences.Api.Controllers
{
    [Route("conferences-module")]
    internal class HomeController : ControllerBase
    {
        public ActionResult<string> Get() => "Conference API";
    }
}
