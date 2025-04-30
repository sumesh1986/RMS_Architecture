using RMS_BAL.Services.Result;
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
      
        Task<IEnumerable<UserPermission>> GetAllPermissionsAsync();
        //Task<IEnumerable<UserPermission>> GetPermissionsByPositionAsync(int positionId);
        //Task<IEnumerable<string>> GetModulesAsync();
        //Task<IEnumerable<string>> GetSectionsByModuleAsync(string moduleName);
        //Task<UserPermission> CreatePermissionAsync(UserPermission permission);
        //Task<UserPermission> UpdatePermissionAsync(UserPermission permission);
        //Task<bool> DeletePermissionAsync(int id);

    }
}
