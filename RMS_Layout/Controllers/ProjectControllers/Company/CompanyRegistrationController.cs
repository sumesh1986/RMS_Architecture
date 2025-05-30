using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers.ProjectControllers.Company
{
    [Route("company/companyregistration")]
    [ApiExplorerSettings(IgnoreApi = true)]

    public class CompanyRegistrationController : Controller
    {
        [HttpGet("")]
        public ActionResult Index()
        {
            return View("~/Views/Company/CompanyRegistration/Index.cshtml");
        }
    }
}
