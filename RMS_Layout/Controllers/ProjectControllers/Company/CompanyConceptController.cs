using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers.ProjectControllers.Company
{

    [Route("company/companyconcept")]
    public class CompanyConceptController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Company/Concept/Index.cshtml");
        }
    }
}
