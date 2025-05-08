using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers.ProjectControllers.Users
{
    [Route("Users/UserSetup")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserSetupController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Users/UserSetup/Index.cshtml");
        }
    }
}
