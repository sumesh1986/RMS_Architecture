using Microsoft.AspNetCore.Mvc;
using RMS_BAL.Services.Company;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_Layout.Controllers.ProjectAPI.ProductSetup.SalesItemHierarchy
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemGroupAPIController : Controller
    {
        private readonly I_ItemGroupService _itemGroupService;
        public ItemGroupAPIController(I_ItemGroupService itemgroupservice)
        {
            _itemGroupService = itemgroupservice;
        }

        ////// Get all Division - normal / search...

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] string? groupname)
        //{
        //    var data = await _itemGroupService.GetALLAsyncService(groupname);
        //    return Ok(new { data });
        //}

        // Get all Item Group - normal / search...
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? itemgroupName)
        {
            var (totalRecords, data) = await _itemGroupService.GetALLAsyncService(page, pageSize, itemgroupName);
            return Ok(new { totalRecords, data });
        }

        // Create ItemGroup...
        [HttpPost("Save")]
        public async Task<IActionResult> create([FromBody] ItemGroupViewModelDTO model)
        {
            //throw new Exception("Thrown manually from the API Controller");
            var result = await _itemGroupService.CreateAsync(model);

            if (!result.Success)
            {
                return Conflict(new { message = result.Message });
            }
            return Ok(new { message = "ItemGroup saved successfully." });
        }

        [HttpPut("{sysid}")]
        public async Task<IActionResult> UpdateItemGroup(int sysid, [FromBody] ItemGroupViewModelDTO model)
        {

            var result = await _itemGroupService.UpdateAsync(model);

            //if (result.Message.Contains("Concept Name already Exists."))
            //{
            //    return Ok(new { message = result.Message });
            //}

            if (!result.Success)
            {
                return Conflict(new { message = result.Message });
            }



            return Ok(new { success = true, message = "ItemGroup Updated Successfully!.", data = result });
        }




        // Deleting the concept...
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _itemGroupService.DeleteAsync(id);

            if (!result)
                return NotFound(new { success = false, message = "ItemGroup not found." });

            return Ok(new { success = true, message = "ItemGroup deleted successfully!." });
        }
    }
}
