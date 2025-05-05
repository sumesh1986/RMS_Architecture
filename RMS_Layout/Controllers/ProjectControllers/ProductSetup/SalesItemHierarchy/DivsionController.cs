using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers.ProjectControllers.ProductSetup.SalesItemHierarchy
{
    public class DivsionController : Controller
    {
        [Route("productsetup/division")]
        [ApiExplorerSettings(IgnoreApi = true)]
      
            public IActionResult Index()
            {
                return View("~/Views/ProductSetup/SalesItemHierarchy/Division/divsionIndex.cshtml");
            }
       
    }
}
