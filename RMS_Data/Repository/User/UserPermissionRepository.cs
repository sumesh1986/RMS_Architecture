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

        public async Task<IEnumerable<string>> GetDistinctModulesAsync()
        {
            return await _context.RolePermissions
                
                .Select(r => r.ModuleName)
                .Distinct()
                .OrderBy(m => m)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistinctSectionsByModuleAsync(string moduleName)
        {
            return await _context.RolePermissions
                
                .Select(r => r.DivisionName)
                .Distinct()
                .OrderBy(d => d)
                .ToListAsync();
        }

        public async Task<IEnumerable<RolePermission>> GetRolePermissionsAsync(string moduleName, string? sectionName = null)
        {
            var query = _context.RolePermissions.Where(r => r.IsActive && r.ModuleName == moduleName);

            if (!string.IsNullOrEmpty(sectionName))
            {
                query = query.Where(r => r.DivisionName == sectionName);
            }

            return await query.OrderBy(r => r.DivisionName)
                            .ThenBy(r => r.Particulars)
                            .ToListAsync();
        }

        public async Task<IEnumerable<PositionPermitted>> GetPositionPermissionsAsync(int positionId)
        {
            return await _context.PositionPermitted
                .Include(p => p.RolePermission)
                .Where(p => p.PositionID == positionId && p.RolePermission.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserPositions>> GetActivePositionsAsync()
        {
            return await _context.UserPositions
                .Where(p => p.Active == "Active")
                .OrderBy(p => p.UserPosition)
                .ToListAsync();
        }

        public async Task<bool> TogglePermissionAsync(int positionId, int particularId, bool isGranted)
        {
            var existingPermission = await _context.PositionPermitted
                .FirstOrDefaultAsync(p => p.PositionID == positionId && p.ParticularID == particularId);

            if (isGranted && existingPermission == null)
            {
                _context.PositionPermitted.Add(new PositionPermitted
                {
                    PositionID = positionId,
                    ParticularID = particularId
                });
            }
            else if (!isGranted && existingPermission != null)
            {
                _context.PositionPermitted.Remove(existingPermission);
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
