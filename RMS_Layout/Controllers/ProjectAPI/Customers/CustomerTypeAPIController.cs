using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMS_BAL.Repository.Interfaces;
using RMS_BAL.Services.Customer;
using RMS_BAL.Services.Interfaces;
using RMS_Data.Data;
using RMS_Models.Models;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.DTO.Customers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RMS_Layout.Controllers.ProjectAPI.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypeAPIController : ControllerBase
    {
        private readonly ICustomerTypeService _customertypeService;

        public CustomerTypeAPIController(ICustomerTypeService customertypeService)
        {
            _customertypeService = customertypeService;
        }

        // Get all customer groups - normal / search...
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? customerNameType)
        {
            var (totalRecords, data) = await _customertypeService.GetAsync(page, pageSize, customerNameType);
            return Ok(new { totalRecords, data });
        }





     


        // Create customer group...
        [HttpPost("save")]
        public async Task<IActionResult> create([FromBody] CustomerTypeDTO model)
        {
            //throw new Exception("Thrown manually from the API Controller");
            var result = await _customertypeService.CreateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = "Customer Type created successfully." });
        }

        // Update the existing group...
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerTypeDTO model)
        {

            var result = await _customertypeService.UpdateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { success = true, message = "Customer Type updated successfully.", data = result });
        }


        // Deleting the customer group...
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customertypeService.DeleteAsync(id);

            if (!result)
                return NotFound(new { success = false, message = "Customer Type not found." });

            return Ok(new { success = true, message = "Customer Type deleted successfully." });
        }
    }
}




