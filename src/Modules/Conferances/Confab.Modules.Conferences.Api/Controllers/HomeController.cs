using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Conferences.Api.Controllers
{
    [Route(BasePath)]
    internal class HomeController : BaseController
    {
        public ActionResult<string> Get() => "Conference API";
    }
}
