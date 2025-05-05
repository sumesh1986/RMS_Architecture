using Microsoft.AspNetCore.Mvc;
using RMS_Data.Data;
using RMS_Models.Models;
using Microsoft.EntityFrameworkCore;


namespace RMS_Layout.Controllers.ProjectControllers.Customers
{
    [Route("Customers/CustomerGroups")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CustomerGroupsController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Customers/CustomerGroups/Index.cshtml");
        }
    }
}
