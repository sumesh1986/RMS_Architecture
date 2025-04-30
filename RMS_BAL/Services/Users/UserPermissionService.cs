using RMS_BAL.Services.Interfaces;
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

        public UserPermissionService(IUserPermissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserPermission>> GetAllPermissionsAsync()
        {
            return await _repository.GetAllAsync();
        }

    }
}
