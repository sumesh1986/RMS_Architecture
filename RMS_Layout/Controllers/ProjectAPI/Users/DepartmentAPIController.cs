using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS_BAL.Services.Interfaces;
using RMS_Models.Models.DTO.Users;

namespace RMS_Layout.Controllers.ProjectAPI.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentAPIController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentAPIController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }
        // Get all customer groups - normal / search...

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? DepartmentsName)

        {
            var (totalRecords, data) = await _departmentsService.GetAsync(page, pageSize, DepartmentsName);
            return Ok(new { totalRecords, data });
        }

        // Create full model
        [HttpPost("save")]
        public async Task<IActionResult> create([FromBody] DepartmentsDTO model)

        {
            //throw new Exception("Thrown manually from the API Controller");
            var result = await _departmentsService.CreateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = "Department created successfully." });
        }


        // Update


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartmentsDTO model)
        {

            var result = await _departmentsService.UpdateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            return Ok(new { success = true, message = "Department updated successfully.", data = result });
        }


        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _departmentsService.DeleteAsync(id);

            if (!result)
                return NotFound(new { success = false, message = "Department  not found." });

            return Ok(new { success = true, message = "Department deleted successfully." });
        }


    }
}
