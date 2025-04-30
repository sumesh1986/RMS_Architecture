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
        Task<IEnumerable<UserPermission>> GetAllAsync();
        //Task<IEnumerable<UserPermission>> GetByPositionIdAsync(int positionId);
        //Task<IEnumerable<string>> GetDistinctModulesAsync();
        //Task<IEnumerable<string>> GetSectionsByModuleAsync(string moduleName);
        //Task<UserPermission> CreateAsync(UserPermission permission);
        //Task<UserPermission> UpdateAsync(UserPermission permission);
        //Task<bool> DeleteAsync(int id);
    }
}
