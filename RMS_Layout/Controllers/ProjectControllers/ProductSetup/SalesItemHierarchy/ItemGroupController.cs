using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers.ProjectControllers.ProductSetup.SalesItemHierarchy
{
    [Route("productsetup/itemGroup")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ItemGroupController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/ProductSetup/SalesItemHierarchy/ItemGroup/itemGroupIndex.cshtml");
        }
    }
}
