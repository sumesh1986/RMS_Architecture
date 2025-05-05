using Microsoft.AspNetCore.Mvc;
using RMS_Data.Data;
using RMS_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace RMS_Layout.Controllers.ProjectControllers.Customers
{

    [Route("Customers/CustomerTitles")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CustomerTitlesController : Controller
    {

        [HttpGet("")]
        public IActionResult CustomerTitile()
        {
            return View("~/Views/Customers/CustomerTitles/CustomerTitle.cshtml");
        }

       
    }
}
