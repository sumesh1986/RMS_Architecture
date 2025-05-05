using Microsoft.AspNetCore.Mvc;
using RMS_BAL.Services.Interfaces;

namespace RMS_Layout.Controllers.ProjectAPI.Dropdown
{
    public class DropdownApiController : Controller
    {
        private readonly IDropdownCommonServices _dropdownCommonServices;

        public DropdownApiController(IDropdownCommonServices dropdownCommonServices)
        {
            _dropdownCommonServices = dropdownCommonServices;
        }

        [HttpGet("api/ProductSalesCategoryAPI")]
        public async Task<IActionResult> Get([FromQuery] int catId, [FromQuery] string categoryname, [FromQuery] int divsionId, [FromQuery] string divisionName)
        {
            var data = await _dropdownCommonServices.GetProductSalesCategoryAsync(catId, categoryname, divsionId, divisionName);
            return Ok(new { data });
        }



    }
}
