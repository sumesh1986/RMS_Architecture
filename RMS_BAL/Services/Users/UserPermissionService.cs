using Microsoft.Extensions.Logging;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.Result;
using RMS_Data.Repository.Interfaces;
using RMS_Data.Repository.User;
using RMS_Models.Models.API_Models.Users;
using RMS_Models.Models.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_BAL.Services.Users
{
    public class UserPermissionService: IUserPermissionService
    {
           private readonly IUserPermissionRepository _repository;
        private readonly ILogger<UserPermissionService> _logger;

        public UserPermissionService(
            IUserPermissionRepository repository,
            ILogger<UserPermissionService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<string>> GetModulesAsync()
        {
            try
            {
                return await _repository.GetDistinctModulesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting modules");
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetSectionsByModuleAsync(string moduleName)
        {
            try
            {
                return await _repository.GetDistinctSectionsByModuleAsync(moduleName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting sections for module {ModuleName}", moduleName);
                throw;
            }
        }
        public async Task<IEnumerable<RMS_Models.Models.DTO.Users.UserPositionsDto>> GetActivePositionsAsync()
        {
            try
            {
                var positions = await _repository.GetActivePositionsAsync();
                return positions.Select(p => new RMS_Models.Models.DTO.Users.UserPositionsDto
                {
                    SysId = p.SysId,
                    UserPosition = p.UserPosition,
                    Active = p.Active
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active positions");
                throw;
            }
        }

        //public async Task<IEnumerable<UserPositionsDto>> GetActivePositionsAsync()
        //{
        //    try
        //    {
        //        var positions = await _repository.GetActivePositionsAsync();
        //        return positions.Select(p => new  RMS_Models.Models.DTO

        //        {
        //            SysId = p.SysId,
        //            UserPosition = p.UserPosition,
        //            Active = p.Active
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error getting active positions");
        //        throw;
        //    }
        //}

        public async Task<IEnumerable<PermissionTreeDTO>> GetPermissionTreeAsync(
            string moduleName, string? sectionName, int positionId)
        {
            try
            {
                var permissions = await _repository.GetRolePermissionsAsync(moduleName, sectionName);
                var grantedPermissions = await _repository.GetPositionPermissionsAsync(positionId);

                return BuildPermissionTree(permissions, grantedPermissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting permission tree for position {PositionId}", positionId);
                throw;
            }
        }

        public async Task<bool> TogglePermissionAsync(TogglePermissionDTO request)
        {
            try
            {
                return await _repository.TogglePermissionAsync(
                    request.PositionId,
                    request.ParticularId,
                    request.IsGranted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling permission for position {PositionId} and particular {ParticularId}",
                    request.PositionId, request.ParticularId);
                throw;
            }
        }

        private List<PermissionTreeDTO> BuildPermissionTree(
            IEnumerable<RolePermission> permissions,
            IEnumerable<PositionPermitted> grantedPermissions)
        {
            var tree = new List<PermissionTreeDTO>();
            var moduleGroups = permissions.GroupBy(p => p.ModuleName);

            foreach (var moduleGroup in moduleGroups)
            {
                var moduleNode = new PermissionTreeDTO
                {
                    Id = -1,
                    ModuleName = moduleGroup.Key,
                    SectionFormControl = moduleGroup.Key,
                    Particulars = moduleGroup.Key,
                    Children = new List<PermissionTreeDTO>()
                };

                foreach (var sectionGroup in moduleGroup.GroupBy(p => p.DivisionName))
                {
                    var sectionNode = new PermissionTreeDTO
                    {
                        Id = -2,
                        ModuleName = moduleGroup.Key,
                        SectionFormControl = sectionGroup.Key,
                        Particulars = sectionGroup.Key,
                        Children = new List<PermissionTreeDTO>()
                    };

                    foreach (var permission in sectionGroup)
                    {
                        var isGranted = grantedPermissions.Any(p => p.ParticularID == permission.ParticularID);
                        sectionNode.Children.Add(new PermissionTreeDTO
                        {
                            Id = permission.ParticularID,
                            ModuleName = permission.ModuleName,
                            SectionFormControl = permission.DivisionName,
                            Particulars = permission.Particulars,
                            IsGranted = isGranted,
                            IsDenied = !isGranted
                        });
                    }

                    moduleNode.Children.Add(sectionNode);
                }

                tree.Add(moduleNode);
            }

            return tree;
        }

        public Task<IEnumerable<UserPositionsDto>> GetUserPositionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetDistinctModulesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserPermissionDto>> GetByPositionIdAsync(int positionId)
        {
            throw new NotImplementedException();
        }

        public Task HasPermissionAsync(int positionId, string moduleName, string particular)
        {
            throw new NotImplementedException();
        }
    }
}
