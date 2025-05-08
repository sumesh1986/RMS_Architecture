using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RMS_BAL.Services.Company;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_Layout.Controllers.ProjectAPI.ProductSetup.SalesItemHierarchy
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSetupDivisionAPIController : Controller
    {
        private readonly IDivisionService _divisionService;
        public ProductSetupDivisionAPIController(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        //// Get all Division - normal / search...
     
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? division = null)
        {
            var data = await _divisionService.GetAsyncService(division);
            return Ok(new { data });
        }


        // Create Division...
        [HttpPost("Save")]
        public async Task<IActionResult> create([FromBody] DivisionViewModelDTO model)
        {
            //throw new Exception("Thrown manually from the API Controller");
            var result = await _divisionService.CreateAsync(model);

            if (!result.Success)
            {
                return Conflict(new { message = result.Message });
            }
            return Ok(new { message = "Division saved successfully." });
        }


        [HttpPut("{sysid}")]
        public async Task<IActionResult> UpdateConcept(int sysid, [FromBody] DivisionViewModelDTO model)
        {

            var result = await _divisionService.UpdateAsync(model);

            //if (result.Message.Contains("Concept Name already Exists."))
            //{
            //    return Ok(new { message = result.Message });
            //}

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }



            return Ok(new { success = true, message = "Division Updated Successfully!.", data = result });
        }




        // Deleting the divsion row...
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _divisionService.DeleteAsync(id);

            if (!result)
                return NotFound(new { success = false, message = "Division not found." });

            return Ok(new { success = true, message = "Division deleted successfully!." });
        }
    }
}
