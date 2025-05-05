using Microsoft.AspNetCore.Mvc;
using RMS_Data.Data;
using RMS_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace RMS_Layout.Controllers.ProjectControllers.Customers
{

    [Route("Customers/CustomerTypes")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CustomerTypesController : Controller
    {
        [HttpGet("")]
        public IActionResult Customertype()
        {
            return View("~/Views/Customers/CustomerTypes/Customertype.cshtml");
        }
    }
}
