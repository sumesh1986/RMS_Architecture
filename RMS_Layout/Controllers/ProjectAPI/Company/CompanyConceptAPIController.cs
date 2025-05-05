using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMS_BAL.Services.Interfaces;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.DTO.Customers;


namespace RMS_Layout.Controllers.ProjectAPI.Company
{

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyConceptAPIController : ControllerBase
    {
        private readonly ICompanyConceptService _companyconceptService;


        public CompanyConceptAPIController(ICompanyConceptService companyconceptService)
        {
            _companyconceptService = companyconceptService;
        }


        // Get all Concept - normal / search...
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? Name)
        {
            var (totalRecords, data) = await _companyconceptService.GetAsync(page, pageSize, Name);
            return Ok(new { totalRecords, data });
        }

        // Create Concept...
        [HttpPost("Save")]
        public async Task<IActionResult> create([FromBody] CompanyConceptDTO model)
        {
            //throw new Exception("Thrown manually from the API Controller");
            var result = await _companyconceptService.CreateAsync(model);

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = "Concept saved successfully." });
        }

        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAll(int page, int pageSize)
        //{
        //    //int totalRecords = await _dbContext.CompanyConcepts.CountAsync();
        //    //var data = await _dbContext.CompanyConcepts
        //    //    .OrderByDescending(c => c.Id) // Sort descending
        //    //    .Skip((page - 1) * pageSize)
        //    //    .Take(pageSize)
        //    //    .Select(c => new
        //    //    {
        //    //        c.Id,
        //    //        c.Name,
        //    //        c.ListofConcept,
        //    //        c.CreatedAt,
        //    //        c.Status
        //    //    })
        //    //    .ToListAsync();
        //    //return Ok(new { data, totalRecords });
        //    return Ok(new {message = "Okay..."});
        //}

        //[HttpPost("Save")]
        //public async Task<IActionResult> Save([FromBody] CompanyConcept conceptModelRequest)
        //{
        //    if (conceptModelRequest == null || string.IsNullOrWhiteSpace(conceptModelRequest.Name))
        //        return BadRequest("Concept name is required.");

        //    //await _dbContext.CompanyConcepts.AnyAsync(c => (c.Name ?? "").ToLower() == (conceptModelRequest.Name ?? "").ToLower());

        //    conceptModelRequest.CreatedAt = DateTime.Now;
        //    await _dbContext.CompanyConcepts.AddAsync(conceptModelRequest);
        //    await _dbContext.SaveChangesAsync();
        //    //return Ok("Concept added successfully!");
        //    //return Ok(new { message = "Concept Saved successfully", group = conceptModelRequest });
        //    return Ok(new { message = "Concept saved successfully", concept = conceptModelRequest });
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateConcept(int id, [FromBody] CompanyConcept model)
        //{
        //    if (id != model.Id)
        //        return BadRequest(new { success = false, message = "ID mismatch." });
        //    var existingConcept = await _dbContext.CompanyConcepts.FindAsync(id);
        //    if (existingConcept == null)
        //        return NotFound(new { success = false, message = "Concept not found." });
        //    existingConcept.Name = model.Name;
        //    existingConcept.ListofConcept = model.ListofConcept;
        //    existingConcept.UpdatedAt = DateTime.Now;
        //    await _dbContext.SaveChangesAsync();
        //    return Ok(new { success = true, message = "Concept Updated Successfully!." });
        //}


        // Delete
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var conceptrow = await _dbContext.CompanyConcepts.FindAsync(id);
        //    if (conceptrow == null)
        //        return NotFound(new { success = false, message = "Customer Group not found." });
        //    _dbContext.CompanyConcepts.Remove(conceptrow);
        //    await _dbContext.SaveChangesAsync();
        //    return Ok(new { success = true, message = "Concept deleted successfully!" });
        //}

        // Update the existing group...



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConcept(int id, [FromBody] CompanyConceptDTO model)
        {

            var result = await _companyconceptService.UpdateAsync(model);

            //if (result.Message.Contains("Concept Name already Exists."))
            //{
            //    return Ok(new { message = result.Message });
            //}

            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }

            

            return Ok(new { success = true, message = "Concept Updated Successfully!.", data = result });
        }




        // Deleting the concept...
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _companyconceptService.DeleteAsync(id);

            if (!result)
                return NotFound(new { success = false, message = "Concept not found." });

            return Ok(new { success = true, message = "Concept deleted successfully!." });
        }
    }
}
