using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RMS_Models.Models;

namespace RMS_Layout.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BranchSetup()
        {
            return View();
        }
        public IActionResult Concept()
        {
            return View();
        }


        public IActionResult Category()
        {
            return View();
        }
        public IActionResult Division()
        {
            return View();
        }
        public IActionResult ItemGroup()
        {
            return View();
        }
        public IActionResult ItemMaster()
        {
            return View();
        }
        public IActionResult Course()
        {
            return View();
        }
        public IActionResult Modifiers()
        {
            return View();
        }
        public IActionResult Combo()
        {
            return View();
        }
        public IActionResult ItemCount()
        {
            return View();
        }
        public IActionResult UpdatePriceinBulk()
        {
            return View();
        }
         public IActionResult Administrative_Tools()
        {
            return View();
        }
        public IActionResult FloorDraft()
        {
            return View();
        }
        public IActionResult TableLayout()
        {
            return View();
        }
        public IActionResult StationSetup()
        {
            return View();
        }
        public IActionResult InvoiceSetup()
        {
            return View();
        }
        public IActionResult QR_Code()
        {
            return View();
        }

        public IActionResult Country()
        {
            return View();
        }

        public IActionResult RegionSetup()
        {
            return View();
        }
        public IActionResult CitySetup()
        {
            return View();
        }
        public IActionResult ZoneAreaSettings()
        {
            return View();
        }

        public IActionResult PhoneMask()
        {
            return View();
        }
        public IActionResult OrderTypes()
        {
            return View();
        }
        public IActionResult SetReminders()
        {
            return View();
        }

        public IActionResult PaymentSetup()
        {
            return View();
        }

        public IActionResult Discounts()
        {
            return View();
        }

        public IActionResult DiscountException()
        {
            return View();
        }

        public IActionResult PriceGroup()
        {
            return View();
        }

        public IActionResult ServiceCharger()
        {
            return View();
        }
        public IActionResult Tax()
        {
            return View();
        }

        public IActionResult Permission()
        {
            return View();
        }
        public IActionResult Performeod()
        {
            return View();
        }

        public IActionResult MTools()
        {
            return View();
        }

        public IActionResult Preview()
        {
            return View();
        }

        public IActionResult ImportSalesandCustomExcel()
        {
            return View();
        }

        public IActionResult ScreenMenu()
        {
            return View();
        }

        public IActionResult ScreenGroup()
        {
            var model = new ScreenGroupViewModel
            {
                ScreenGroup = new ScreenGroup
                {
                    ScreenName = "Default Screen",  // Provide default values
                    GroupName = "Default Group",
                    IsActive = true // You can set this to false if needed
                },
                ScreenGroupList = new List<ScreenGroup>(),  // Ensure it's initialized
                AvailableScreens = new List<string>() // Ensure it's initialized
            };

            return View(model);
        }

        public IActionResult ScreenSubgroup()
        {
            return View();
        }

        public IActionResult POS_SCREEN()
        {
            return View();
        }


        public IActionResult CustomersSetup()
        {
            return View();
        }


        public IActionResult Registration()
        {
            return View();
        }

        

        public IActionResult customerlist()
        {
            return View();
        }
        public IActionResult customertype()
        {
            return View();
        }
        public IActionResult PolyDisplay()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
