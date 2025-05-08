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
    public class CustomerTitleAPIController : ControllerBase
    {

        private readonly ICustomerTitleService _customertitleService;

        public CustomerTitleAPIController(ICustomerTitleService customertitleService)
        {
            _customertitleService = customertitleService;
        }

        // Get all customer groups - normal / search...
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? customerNameTitle)
        {
            var (totalRecords, data) = await _customertitleService.GetAsync(page, pageSize, customerNameTitle);
            return Ok(new { totalRecords, data });
        }



        // Create customer group...
        [HttpPost("save")]
        public async Task<IActionResult> create([FromBody] CustomerTitleDTO model)
        {
            //throw new Exception("Thrown manually from the API Controller");
            var result = await _customertitleService.CreateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = "Customer Titile created successfully." });
        }
        // Update the existing group...
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerTitleDTO model)
        {

            var result = await _customertitleService.UpdateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { success = true, message = "Customer Titile updated successfully.", data = result });
        }


        // Deleting the customer group...
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customertitleService.DeleteAsync(id);

            if (!result)
                return NotFound(new { success = false, message = "Customer Titile not found." });

            return Ok(new { success = true, message = "Customer Titile deleted successfully." });
        }

    }
}
