using Microsoft.AspNetCore.Mvc;
using Admin_Lte.Models;
using RMS_Models.Models;

namespace Admin_Lte.Controllers
{
    public class RegisterController : Controller
    {
      
        public IActionResult Index()
        {
            List<Registration> model = new()
    {
        new Registration
        {
            CompanyName = "Test Company",
            OwnerName = "John Doe",
            FamilyName = "Doe",
            Country = "USA",
            Place = "New York",
            Address = "123 Main St",
            Email = "test@example.com",
            Phone = "123456789012",
            ProductId = GenerateProductId(),
            RegistrationNumber = GenerateRegistrationNumber(),
            FileCreatedOn = DateTime.Now,
            FileCreatedAt = DateTime.Now.ToString("HH:mm:ss:ff"),
            IsHeadOffice = false
        }
    };

            return View(model); // ✅ Now returning a collection
        }

        [HttpPost]
        public IActionResult Register(Registration model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            // Add your registration logic here

            return RedirectToAction("Success");
        }

        private string GenerateProductId()
        {
            // Implement your product ID generation logic
            return "661044592101616150120875";
        }

        private string GenerateRegistrationNumber()
        {
            // Implement your registration number generation logic
            return "15306035037";
        }

    }
}
