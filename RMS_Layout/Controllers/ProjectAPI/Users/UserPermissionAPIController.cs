using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;
using RMS_Models.Models.API_Models.Users;

namespace RMS_Layout.Controllers.ProjectAPI.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionAPIController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public UserPermissionAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("positions")]
        public async Task<ActionResult> GetUserPositions()
        {
            try
            {
                var positions = await _context.UserPositions
                    .Select(p => new
                    {
                        p.SysId,
                        p.UserPosition
                    })
                    .ToListAsync();

                return Ok(new { success = true, data = positions });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error fetching positions", error = ex.Message });
            }
        }
    }
}
