using Admin_Lte.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Lte.Controllers
{
    public class UserSetUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(UserSetup model)
        {
            if (ModelState.IsValid)
            {
                // Add your save logic here
                return RedirectToAction("Index");
            }
            return View("Index", model);
        }
    }
}
