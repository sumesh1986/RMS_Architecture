using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Mvc;
using RMS_BAL.Services.Interfaces;
using RMS_Models.Models;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.DTO.Customers;
using RMS_Models.Models.ServiceModels;


namespace RMS_Layout.Controllers.ProjectAPI.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyRegistrationAPIController : ControllerBase
    {

        private readonly ICompanyRegistrationService _ser;
        public CompanyRegistrationAPIController(ICompanyRegistrationService customerService)
        {
            _ser = customerService;
        }


        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var groups = await _ser.GetAsync(id);
            return Ok(new { success = true, data = groups });
        }


        [HttpPut("update")]
        public async Task<IActionResult> update(RegistrationDTO reg)
        {
            var result = _ser.UpdateAsync(reg);
            return StatusCode(200, new { message = "Company registration updated successfully.", data = result });
        }
    }
}
