//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using RMS_BAL.Services.Company;
//using RMS_BAL.Services.Interfaces;
//using RMS_Models.Models.API_Models.Customers;

//namespace RMS_Layout.Controllers.ProjectAPI.Customers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerApiController : ControllerBase
//    {

//        private readonly ICustomerService _customerService;
//        public CustomerApiController(ICustomerService customerService)
//        {
//            _customerService = customerService;
//        }


//        [HttpGet]
//        public async Task<IActionResult> Get([FromQuery] string? title = null)
//        {
//            var data = await _customerService.GetAsyncService(title);
//            return Ok(new { data });
//        }




//    }



//}
