using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.Users;



namespace RMS_Data.Repository.User
{
    public class UserPermissionRepository:IUserPermissionRepository
    {
        private readonly ApplicationDbContext _context;

        public UserPermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserPermission>> GetAllAsync()
        {
            return await _context.RolePermissions
                .Include(p => p.UserPosition)
                .ToListAsync();
        }

        //public async Task<IEnumerable<UserPermission>> GetByPositionIdAsync(int positionId)
        //{
        //    return await _context.UserPermissions
        //        .Where(p => p.UserPositionId == positionId)
        //        .ToListAsync();
        //}

        //public async Task<IEnumerable<string>> GetDistinctModulesAsync()
        //{
        //    return await _context.UserPermissions
        //        .Select(p => p.ModuleName)
        //        .Distinct()
        //        .ToListAsync();
        //}

        //public async Task<IEnumerable<string>> GetSectionsByModuleAsync(string moduleName)
        //{
        //    return await _context.UserPermissions
        //        .Where(p => p.ModuleName == moduleName)
        //        .Select(p => p.SectionName)
        //        .Distinct()
        //        .ToListAsync();
        //}

        //public async Task<UserPermission> CreateAsync(UserPermission permission)
        //{
        //    _context.UserPermissions.Add(permission);
        //    await _context.SaveChangesAsync();
        //    return permission;
        //}

        //public async Task<UserPermission> UpdateAsync(UserPermission permission)
        //{
        //    _context.Entry(permission).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return permission;
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var permission = await _context.UserPermissions.FindAsync(id);
        //    if (permission == null)
        //        return false;

        //    _context.UserPermissions.Remove(permission);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
    }
}
