using Microsoft.AspNetCore.Mvc;
using RMS_Data.Data;
using RMS_Models.Models;
using Microsoft.EntityFrameworkCore;


namespace RMS_Layout.Controllers.ProjectControllers.Customers
{
    [Route("Customers/CustomerGroups")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CustomerGroupsController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/Customers/CustomerGroups/Index.cshtml");
        }
        // GET: CustomerGroups/Create
        //public IActionResult Create()
        //{
        //     var viewModel = new CustomerGroupViewModel
        //    {
        //        CustomerGroups = _db.CustomerGroups.ToList()
        //    };

        //    return View(viewModel);
        //}

        //// POST: CustomerGroups/Create
        //[HttpPost]
        //public IActionResult Create([FromBody] CustomerGroup model)
        //{
        //    if (string.IsNullOrWhiteSpace(model.GroupName))
        //        return BadRequest("Group Name is required.");

        //    _db.CustomerGroups.Add(model);
        //    _db.SaveChanges();

        //    return Json(new { success = true, message = "Saved successfully." });
        //}



        //// POST: CustomerGroups/Edit
        //[HttpPost]
        //public async Task<JsonResult> Edit(CustomerGroup model)
        //{
        //    if (model.SysId == 0)
        //        return Json(new { success = false, message = "Invalid ID." });

        //    var group = await _db.CustomerGroups.FindAsync(model.SysId);
        //    if (group == null)
        //        return Json(new { success = false, message = "Customer Group not found." });

        //    group.GroupName = model.GroupName;
        //    group.Active = model.Active == "Yes" ? "Yes" : "No";

        //    await _db.SaveChangesAsync();
        //    return Json(new { success = true, message = "Customer Group updated." });
        //}

        //// POST: CustomerGroups/Delete
        //[HttpPost]
        //public async Task<JsonResult> Delete(int id)
        //{
        //    var group = await _db.CustomerGroups.FindAsync(id);
        //    if (group == null)
        //        return Json(new { success = false, message = "Customer Group not found." });

        //    _db.CustomerGroups.Remove(group);
        //    await _db.SaveChangesAsync();

        //    return Json(new { success = true, message = "Customer Group deleted." });
        //}

        //// Optional: For AJAX GetAll call
        //public async Task<JsonResult> GetAll()
        //{
        //    var groups = await _db.CustomerGroups.ToListAsync();
        //    return Json(groups);
        //}



    }
}
