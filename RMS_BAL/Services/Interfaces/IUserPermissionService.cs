using RMS_BAL.Services.Result;
using RMS_BAL.Services.Users;
using RMS_Models.Models.API_Models.Users;
using RMS_Models.Models.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_BAL.Services.Interfaces
{
    public interface IUserPermissionService
    {

        Task<IEnumerable<string>> GetModulesAsync();
        Task<IEnumerable<string>> GetSectionsByModuleAsync(string moduleName);
        Task<IEnumerable<UserPositionsDto>> GetActivePositionsAsync();
        Task<IEnumerable<PermissionTreeDTO>> GetPermissionTreeAsync(string moduleName, string? sectionName, int positionId);
        Task<bool> TogglePermissionAsync(TogglePermissionDTO request);
        Task<IEnumerable<UserPositionsDto>> GetUserPositionsAsync();
        Task<IEnumerable<string>> GetDistinctModulesAsync();
        Task<IEnumerable<UserPermissionDto>> GetByPositionIdAsync(int positionId);
        Task HasPermissionAsync(int positionId, string moduleName, string particular);
    }
}
  




