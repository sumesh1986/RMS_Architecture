using Microsoft.AspNetCore.Mvc;
using RMS_Data.Data;
using RMS_Models.Models.API_Models.Company;


namespace RMS_Layout.Controllers.ProjectAPI.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyConceptAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyConceptAPIController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            //int totalRecords = await _dbContext.CompanyConcepts.CountAsync();
            //var data = await _dbContext.CompanyConcepts
            //    .OrderByDescending(c => c.Id) // Sort descending
            //    .Skip((page - 1) * pageSize)
            //    .Take(pageSize)
            //    .Select(c => new
            //    {
            //        c.Id,
            //        c.Name,
            //        c.ListofConcept,
            //        c.CreatedAt,
            //        c.Status
            //    })
            //    .ToListAsync();
            //return Ok(new { data, totalRecords });
            return Ok(new {message = "Okay..."});
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] CompanyConcept conceptModelRequest)
        {
            if (conceptModelRequest == null || string.IsNullOrWhiteSpace(conceptModelRequest.Name))
                return BadRequest("Concept name is required.");

            //await _dbContext.CompanyConcepts.AnyAsync(c => (c.Name ?? "").ToLower() == (conceptModelRequest.Name ?? "").ToLower());

            conceptModelRequest.CreatedAt = DateTime.Now;
            await _dbContext.CompanyConcepts.AddAsync(conceptModelRequest);
            await _dbContext.SaveChangesAsync();
            //return Ok("Concept added successfully!");
            //return Ok(new { message = "Concept Saved successfully", group = conceptModelRequest });
            return Ok(new { message = "Concept saved successfully", concept = conceptModelRequest });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConcept(int id, [FromBody] CompanyConcept model)
        {
            if (id != model.Id)
                return BadRequest(new { success = false, message = "ID mismatch." });
            var existingConcept = await _dbContext.CompanyConcepts.FindAsync(id);
            if (existingConcept == null)
                return NotFound(new { success = false, message = "Concept not found." });
            existingConcept.Name = model.Name;
            existingConcept.ListofConcept = model.ListofConcept;
            existingConcept.UpdatedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return Ok(new { success = true, message = "Concept Updated Successfully!." });
        }
        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var conceptrow = await _dbContext.CompanyConcepts.FindAsync(id);
            if (conceptrow == null)
                return NotFound(new { success = false, message = "Customer Group not found." });
            _dbContext.CompanyConcepts.Remove(conceptrow);
            await _dbContext.SaveChangesAsync();
            return Ok(new { success = true, message = "Concept deleted successfully!" });
        }
    }
}
