
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using RMS_BAL.Services.Customer;
using RMS_BAL.Services.Interfaces;

using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.DTO.Customers;


namespace RMS_Layout.Controllers.ProjectAPI.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {

        private readonly ICustomerService _service;
        public CustomerApiController(ICustomerService customerService)
        {
            _service = customerService;
        }


        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] string? nametitle = null)
        //{
        //    var data = await _customerService.GetAsyncService(nametitle);
        //    //return Ok(data);
        //    return Ok(new { data });

        //    //return Ok(new { data = data ?? Enumerable.Empty<CustomerViewModel>() });
        //}

        [HttpGet("titles")]
        public async Task<IActionResult> Gettitles()
        {
            try
            {
                var titles = await _service.GettitlesAsync();
                return Ok(new { success = true, data = titles });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error fetching modules", error = ex.Message });
            }
        }

        [HttpGet("groups")]
        public async Task<IActionResult> Getgroups()
        {
            try
            {
                var groups = await _service.GetgroupsAsync();
                return Ok(new { success = true, data = groups });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error fetching modules", error = ex.Message });
            }
        }

        [HttpGet("types")]
        public async Task<IActionResult> Gettypes()
        {
            try
            {
                var groups = await _service.GettypesAsync();
                return Ok(new { success = true, data = groups });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error fetching modules", error = ex.Message });
            }
        }
        [HttpGet("price")]
        public async Task<IActionResult> Getprice()
        {
            try
            {
                var groups = await _service.GetpriceAsync();
                return Ok(new { success = true, data = groups });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error fetching modules", error = ex.Message });
            }
        }

        [HttpGet("discount")]
        public async Task<IActionResult> Getdiscount()
        {
            try
            {
                var groups = await _service.GetdiscountAsync();
                return Ok(new { success = true, data = groups });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error fetching modules", error = ex.Message });
            }


        }




        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? itemgroupName)
        //{
        //    var (totalRecords/*, data*/) = await _service.GetALLAsyncService(page, pageSize, itemgroupName);
        //    return Ok(new { totalRecords/*, data*/ });
        //}


        [HttpPost("Save")]
        public async Task<IActionResult> create([FromBody] CustomersMainDTO model)
        {
            //throw new Exception("Thrown manually from the API Controller");
            var result = await _service.CreateAsync(model);

            if (!result.Success)
            {
                return Conflict(new { message = result.Message });
            }
            return Ok(new { message = "customer  saved successfully." });
        }











    }



}






