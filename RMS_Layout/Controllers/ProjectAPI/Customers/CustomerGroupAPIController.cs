using Microsoft.AspNetCore.Mvc;
using RMS_BAL.Repository.Interfaces;
using RMS_Models.Models.DTO.Customers;

namespace RMS_Layout.Controllers.ProjectAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupAPIController : ControllerBase
    {
        private readonly ICustomerGroupService _customergroupService;

        public CustomerGroupAPIController(ICustomerGroupService customergroupService)
        {
            _customergroupService = customergroupService;
        }

        // Get all customer groups - normal / search...
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? customerGroupName)
        {
            var (totalRecords, data) = await _customergroupService.GetAsync(page, pageSize, customerGroupName);
            return Ok(new { totalRecords, data });
        }




        // Create customer group...
        [HttpPost("save")]
        public async Task<IActionResult> create([FromBody] CustomerGroupDTO model)
        {
            //throw new Exception("Thrown manually from the API Controller");
            var result = await _customergroupService.CreateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = "Customer Group created successfully." });
        }

        // Update the existing group...
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerGroupDTO model)
        {

            var result = await _customergroupService.UpdateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { success = true, message = "Customer Group updated successfully.", data = result });
        }


        // Deleting the customer group...
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customergroupService.DeleteAsync(id);

            if (!result)
                return NotFound(new { success = false, message = "Customer Group not found." });

            return Ok(new { success = true, message = "Customer Group deleted successfully." });
        }
    }
}
