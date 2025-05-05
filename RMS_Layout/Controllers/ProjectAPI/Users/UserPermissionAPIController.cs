using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMS_BAL.Services.Interfaces;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;
using RMS_Layout.Controllers.ProjectControllers.Users;
using RMS_Models.Models.API_Models.Users;
using RMS_Models.Models.DTO.Users;
using System.ComponentModel.DataAnnotations;

namespace RMS_Layout.Controllers.ProjectAPI.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionAPIController : ControllerBase
    {
        private readonly IUserPermissionService _service;
        private readonly ILogger<UserPermissionController> _logger;

        public UserPermissionAPIController(IUserPermissionService service, ILogger<UserPermissionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("modules")]
        public async Task<IActionResult> GetModules()
        {
            try
            {
                var modules = await _service.GetDistinctModulesAsync();
                return Ok(new { success = true, data = modules });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching modules");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("sections/{moduleName}")]
        public async Task<IActionResult> GetSections(string moduleName)
        {
            try
            {
                if (string.IsNullOrEmpty(moduleName))
                    return BadRequest(new { success = false, message = "Module name is required" });

                var sections = await _service.GetSectionsByModuleAsync(moduleName);
                return Ok(new { success = true, data = sections });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching sections");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("positions")]
        public async Task<IActionResult> GetPositions()
        {
            try
            {
                var positions = await _service.GetUserPositionsAsync();
                return Ok(new { success = true, data = positions });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching positions");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpGet("permissions/{positionId}")]
        public async Task<IActionResult> GetPermissionsByPosition(int positionId)
        {
            try
            {
                if (positionId <= 0)
                    return BadRequest(new { success = false, message = "Invalid position ID" });

                var permissions = await _service.GetByPositionIdAsync(positionId);
                return Ok(new { success = true, data = permissions });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching permissions");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPost("toggle")]
        public async Task<IActionResult> TogglePermission([FromBody] TogglePermissionDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { success = false, message = "Invalid request" });

                var result = await _service.TogglePermissionAsync(request);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling permission");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        //[HttpGet("check/{positionId}/{moduleName}/{particular}")]
        //public async Task<IActionResult> CheckPermission(
        //    int positionId,
        //    string moduleName,
        //    string particular)
        //{
        //    try
        //    {
        //        if (positionId <= 0 || string.IsNullOrEmpty(moduleName) || string.IsNullOrEmpty(particular))
        //            return BadRequest(new { success = false, message = "Invalid parameters" });

        //        var hasPermission = await _service.HasPermissionAsync(positionId, moduleName, particular);
        //        return Ok(new { success = true, data = hasPermission });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error checking permission");
        //        return StatusCode(500, new { success = false, message = ex.Message });
        //    }
        //}
    }
}

        //private readonly IUserPermissionRepository _repository = repository;
        //private readonly ILogger<UserPermissionController> _logger = logger;

        //[HttpGet("modules")]
        //public async Task<IActionResult> GetModules()
        //{
        //    try
        //    {
        //        var modules = await _repository.GetDistinctModulesAsync();
        //        return Ok(new { success = true, data = modules });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error retrieving modules");
        //        return StatusCode(500, new { success = false, message = "Failed to retrieve modules" });
        //    }
        //}

        //[HttpGet("sections/{moduleName}")]
        //public async Task<IActionResult> GetSections(string moduleName)
        //{
        //    try
        //    {
        //        var sections = await _repository.GetDistinctSectionsByModuleAsync(moduleName);
        //        return Ok(new { success = true, data = sections });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error retrieving sections");
        //        return StatusCode(500, new { success = false, message = "Failed to retrieve sections" });
        //    }
        //}

        //[HttpGet("permissions")]
        //public async Task<IActionResult> GetPermissions(
        //    [FromQuery] string moduleName,
        //    [FromQuery] string? sectionName,
        //    [FromQuery] int positionId)
        //{
        //    try
        //    {
        //        var permissions = await _repository.GetRolePermissionsAsync(moduleName, sectionName);
        //        var positionPermissions = await _repository.GetPositionPermissionsAsync(positionId);

        //        var permissionTree = BuildPermissionTree(permissions, positionPermissions);
        //        return Ok(new { success = true, data = permissionTree });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error retrieving permissions");
        //        return StatusCode(500, new { success = false, message = "Failed to retrieve permissions" });
        //    }
        //}

        //[HttpPost("toggle")]
        //public async Task<IActionResult> TogglePermission([FromBody] TogglePermissionDTO request)
        //{
        //    try
        //    {
        //        var result = await _repository.TogglePermissionAsync(
        //            request.PositionId,
        //            request.ParticularId,
        //            request.IsGranted);

        //        return Ok(new { success = true, data = result });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error toggling permission");
        //        return StatusCode(500, new { success = false, message = "Failed to update permission" });
        //    }
        //}

        //private List<PermissionTreeDTO> BuildPermissionTree(
        //    IEnumerable<RolePermission> permissions,
        //    IEnumerable<PositionPermitted> positionPermissions)
        //{
        //    var tree = new List<PermissionTreeDTO>();
        //    var moduleGroups = permissions.GroupBy(p => p.ModuleName);

        //    foreach (var moduleGroup in moduleGroups)
        //    {
        //        var moduleNode = new PermissionTreeDTO
        //        {
        //            Id = -1,
        //            ModuleName = moduleGroup.Key,
        //            SectionFormControl = moduleGroup.Key,
        //            Particulars = moduleGroup.Key,
        //            IsGranted = false,
        //            IsDenied = false
        //        };

        //        foreach (var sectionGroup in moduleGroup.GroupBy(p => p.DivisionName))
        //        {
        //            var sectionNode = new PermissionTreeDTO
        //            {
        //                Id = -2,
        //                ModuleName = moduleGroup.Key,
        //                SectionFormControl = sectionGroup.Key,
        //                Particulars = sectionGroup.Key,
        //                IsGranted = false,
        //                IsDenied = false
        //            };

        //            foreach (var permission in sectionGroup)
        //            {
        //                var isGranted = positionPermissions.Any(p => p.ParticularID == permission.ParticularID);
        //                sectionNode.Children.Add(new PermissionTreeDTO
        //                {
        //                    Id = permission.ParticularID,
        //                    ModuleName = permission.ModuleName,
        //                    SectionFormControl = permission.DivisionName,
        //                    Particulars = permission.Particulars,
        //                    IsGranted = isGranted,
        //                    IsDenied = !isGranted
        //                });
        //            }

        //            moduleNode.Children.Add(sectionNode);
        //        }

        //        tree.Add(moduleNode);
        //    }

        //    return tree;
        //}
  
   

