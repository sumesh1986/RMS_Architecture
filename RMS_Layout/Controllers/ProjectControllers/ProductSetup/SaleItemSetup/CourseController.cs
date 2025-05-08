using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers.ProjectControllers.ProductSetup.SaleItemSetup
{
    [Route("productsetup/course")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/ProductSetup/SaleItemSetup/Course/courseIndex.cshtml");
        }
    }
}
