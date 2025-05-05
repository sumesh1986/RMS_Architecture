using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers.ProjectControllers.Users
{

    [Route("Users/UserRole")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserRoleController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Users/UserRole/Index.cshtml");
        }
    }
}
