using Admin_Lte.Models;
using Microsoft.AspNetCore.Mvc;
using RMS_Models.Models;

namespace RMS_Layout.Controllers.ProjectControllers.Users
{
    [Route("Users/Department")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DepartmentController : Controller
    {
        

        public IActionResult Index()
        {

            return View("~/Views/Users/Department/Index.cshtml");
        }

        

    }
}
