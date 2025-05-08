using Microsoft.AspNetCore.Mvc;
using RMS_BAL.Services.Company;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_Layout.Controllers.ProjectAPI.ProductSetup.SalesItemHierarchy
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSetupCategoryAPIController : Controller
    {
        private readonly IProductSetupCategoryService _productsetupcategoryService;
        public ProductSetupCategoryAPIController(IProductSetupCategoryService productsetupcategoryService)
        {
            _productsetupcategoryService = productsetupcategoryService;
        }


        // Get all Category - normal / search...
        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? category)
        //{
        //    var (totalRecords, data) = await _productsetupcategoryService.GetAsync(page, pageSize, category);
        //    return Ok(new { totalRecords, data });
        //}

        // Get all Category - normal / search...
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? category = null)
        {
            var data = await _productsetupcategoryService.I_GetALLAsyncService(category);
            return Ok(new { data });
        }

        // Create Category...
        [HttpPost("Save")]
        public async Task<IActionResult> create([FromBody] CategoryViewModelDTO model)
        {
            //throw new Exception("Thrown manually from the API Controller");
            var result = await _productsetupcategoryService.CreateAsync(model);

            if (!result.Success)
            {
                return Conflict(new { message = result.Message });
            }
            return Ok(new { message = "Category saved successfully." });
        }


        [HttpPut("{sysid}")]
        public async Task<IActionResult> UpdateConcept(int sysid, [FromBody] CategoryViewModelDTO model)
        {

            var result = await _productsetupcategoryService.UpdateAsync(model);

            //if (result.Message.Contains("Concept Name already Exists."))
            //{
            //    return Ok(new { message = result.Message });
            //}

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }



            return Ok(new { success = true, message = "Category Updated Successfully!.", data = result });
        }




        // Deleting the concept...
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productsetupcategoryService.DeleteAsync(id);

            if (!result)
                return NotFound(new { success = false, message = "Category not found." });

            return Ok(new { success = true, message = "Category deleted successfully!." });
        }

    }
}
