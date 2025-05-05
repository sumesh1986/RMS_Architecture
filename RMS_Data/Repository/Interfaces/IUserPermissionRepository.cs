using RMS_Models.Models.API_Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Data.Repository.Interfaces
{
    public interface IUserPermissionRepository
    {

        Task<IEnumerable<string>> GetDistinctModulesAsync();
        Task<IEnumerable<string>> GetDistinctSectionsByModuleAsync(string moduleName);
        Task<IEnumerable<RolePermission>> GetRolePermissionsAsync(string moduleName, string? sectionName = null);
        Task<IEnumerable<PositionPermitted>> GetPositionPermissionsAsync(int positionId);
        Task<IEnumerable<UserPositions>> GetActivePositionsAsync();
        Task<bool> TogglePermissionAsync(int positionId, int particularId, bool isGranted);

        //Task<IEnumerable<string>> GetDistinctModulesAsync();
        //Task<IEnumerable<string>> GetSectionsByModuleAsync(string moduleName);
        //Task<IEnumerable<UserPositions>> GetUserPositionsAsync();
        //Task<IEnumerable<UserPermission>> GetByPositionIdAsync(int positionId);
        //Task TogglePermissionAsync(int positionId, int particularId, bool isGranted);
        //Task<bool> HasPermissionAsync(int positionId, string moduleName, string particular);
        //Task<IEnumerable<UserPermission>> GetPermissionsByModuleAsync(int positionId, string moduleName);
    }
}
