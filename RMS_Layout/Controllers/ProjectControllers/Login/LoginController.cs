using System.Drawing;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;

namespace RMS_Layout.Controllers.ProjectControllers.Login
{
    [Route("Login")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class LoginController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
            return View("~/Views/Home/Login.cshtml");
        }
    }

}
