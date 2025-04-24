using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers
{
    public class LoginController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Default credentials
            string defaultUsername = "admin";
            string defaultPassword = "1234";

            if (username == defaultUsername && password == defaultPassword)
            {
                // Set authentication cookie or session
                HttpContext.Session.SetString("username", username); // Or use ASP.NET Identity if enabled

                // Redirect to Layout or Dashboard
                return RedirectToAction("Index", "Home"); // Change "Dashboard" to your main controller
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            //return View();
            return View("Login", model: null); // or any model you're passing
            //return View("Index"); // Return to same view with error
        }


        //        ⚠️ Reminder
        //id = "..." is for HTML/JS
        //name = "..." is for server-side model binding
        //[HttpPost]
        //public IActionResult Login()
        //{
        //    string username = Request.Form["txtusername"].ToString();
        //    string password = Request.Form["txtpassword"].ToString();


        //    string defaultUsername = "admin";
        //    string defaultPassword = "1234";

        //    if (username == defaultUsername && password == defaultPassword)
        //    {
        //        HttpContext.Session.SetString("username", username);
        //        return RedirectToAction("Index", "Home");
        //    }

        //    ViewBag.ErrorMessage = "Invalid username or password.";
        //    return View();
        //}

    }
}
