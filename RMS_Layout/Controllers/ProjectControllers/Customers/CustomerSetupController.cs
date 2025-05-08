using Microsoft.AspNetCore.Mvc;
using RMS_Data.Data;
using RMS_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace RMS_Layout.Controllers.ProjectControllers.Customers
{

    [Route("Customers/CustomerSetup")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CustomerSetupController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> Customer()
        {
            return View("~/Views/Customers/CustomerSetup/Customer.cshtml");
        }
    }
}
