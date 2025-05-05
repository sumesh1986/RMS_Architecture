using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMS_BAL.Repository.Interfaces;
using RMS_BAL.Services.Customer;
using RMS_BAL.Services.Interfaces;
using RMS_Data.Data;
using RMS_Models.Models.API_Models.Users;
using RMS_Models.Models.DTO.Customers;
using RMS_Models.Models.DTO.Users;

namespace RMS_Layout.Controllers.ProjectAPI.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleAPIController : ControllerBase
    {
        private readonly IUserPositionsService _userpositionsService;

        public UserRoleAPIController(IUserPositionsService userpositionsService)
        {
            _userpositionsService = userpositionsService;
        }
        // Get all customer groups - normal / search...

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? UserpositionsName)
        
        {
            var (totalRecords, data) = await _userpositionsService.GetAsync(page, pageSize, UserpositionsName);
            return Ok(new { totalRecords, data });
        }

        // Create full model
        [HttpPost("save")]
        public async Task<IActionResult> create([FromBody] UserPositionsDto model)
        {
            //throw new Exception("Thrown manually from the API Controller");
            var result = await _userpositionsService.CreateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = "User role/position created successfully." });
        }


        // Update

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserPositionsDto model)
        {

            var result = await _userpositionsService.UpdateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { success = true, message = "User Role/position updated successfully.", data = result });
        }


        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userpositionsService.DeleteAsync(id);

            if (!result)
                return NotFound(new { success = false, message = "User Role  not found." });

            return Ok(new { success = true, message = "User Role/position deleted successfully." });
        }
    }
}
