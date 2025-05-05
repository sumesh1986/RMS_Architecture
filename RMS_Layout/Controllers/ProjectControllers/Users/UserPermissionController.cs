using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers.ProjectControllers.Users
{

    [Route("Users/UserPermission")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserPermissionController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Users/UserPermission/Index.cshtml");
        }
    }
}
