using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers.ProjectControllers.ProductSetup.SalesItemHierarchy
{
    [Route("productsetup/category")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/ProductSetup/SalesItemHierarchy/Category/categoryIndex.cshtml");
        }
    }
}
