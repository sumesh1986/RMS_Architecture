using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS_BAL.Repository.Interfaces;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.Result;
using RMS_Data.Repository.Interfaces;
using RMS_Data.Repository.User;
using RMS_Data.Service.Interfaces;
using RMS_Models.Models;

using RMS_Models.Models.API_Models.Users;

using RMS_Models.Models.DTO.Users;


namespace RMS_BAL.Services.Users
{
    public class UserPositionsService: IUserPositionsService
    {
        private readonly IUserPositionsRepository _repository;

        public UserPositionsService(IUserPositionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int totalRecords, IEnumerable<UserPositionsDto> data)> GetAsync(int page, int pageSize, string? groupName = null)
        {
            var (totalRecords, groups) = await _repository.GetAsync(page, pageSize, groupName);

            var data = groups.Select(g => new UserPositionsDto
            {
                SysId = g.SysId,
                UserPosition = g.UserPosition,
                Active = g.Active
            });

            return (totalRecords, data);
        }
      
        public async Task<Result<UserPositions>> CreateAsync(UserPositionsDto model)
        {
            // Validation...
            if (string.IsNullOrWhiteSpace(model.UserPosition))
            {
                return Result<UserPositions>.FailureResult("User Role/Position Name is required.");
            }

            // cheking existing group...
            var existing = await _repository.GetByGroupNameAsync(model.UserPosition);
            if (existing is not null || existing != null)
            {
                return Result<UserPositions>.FailureResult("User Role/Position  already exists.");
            }

            // mapping DTO to entity(main class)...
            var userPositions = new UserPositions
            {
                UserPosition = model.UserPosition,
                Active = model.Active,
                //InsertedTime = DateTime.Now
            };

            // creating group...
            var createdGroup = await _repository.CreateAsync(userPositions);

            return Result<UserPositions>.SuccessResult(createdGroup);
        }

        public async Task<Result<UserPositions>> UpdateAsync(UserPositionsDto model)
        {
            // Validation
            if (model.SysId == 0)
            {
                return Result<UserPositions>.FailureResult("Invalid ID. Update not possible.");
            }

            if (string.IsNullOrWhiteSpace(model.UserPosition))
            {
                return Result<UserPositions>.FailureResult("User Role/Position Name should not be empty.");
            }

            var existing = await _repository.GetByIdAsync(model.SysId);
            if (existing == null)
            {
                return Result<UserPositions>.FailureResult("Record not found.");
            }

            // 🔥 Checking Duplicate Name but Excluding itself (SysId != model.SysId)
            var duplicate = await _repository.GetByGroupNameAsync(model.UserPosition);
            if (duplicate != null && duplicate.SysId != model.SysId)
            {
                return Result<UserPositions>.FailureResult("User Role/Position Name already exists.");
            }

            // 🔥 Checking No Changes
            bool isNameSame = existing.UserPosition.Equals(model.UserPosition, StringComparison.OrdinalIgnoreCase);
            bool isStatusSame = existing.Active == model.Active;

            if (isNameSame && isStatusSame)
            {
                return Result<UserPositions>.FailureResult("No changes detected. Update not required.");
            }

            // Update entity
            existing.UserPosition = model.UserPosition;
            existing.Active = model.Active;

            var updatedGroup = await _repository.UpdateAsync(existing);

            return Result<UserPositions>.SuccessResult(updatedGroup);
        }



        //public async Task<Result<UserPositions>> UpdateAsync(UserPositionsDto model)
        //{
        //    // Validation
        //    if (model.SysId == 0)
        //    {
        //        return Result<UserPositions>.FailureResult("User Role/Position Name should not be empty.");
        //    }

        //    // checking existing group...
        //    var group = await _repository.GetByGroupNameAsync(model.UserPosition);
        //    if (group != null)
        //    {
        //        if (model.Active == group.Active)
        //        {
        //            return Result<UserPositions>.FailureResult("User Role/Position Name already exists.");
        //        }
        //    }

        //    var existing = await _repository.GetByIdAsync(model.SysId);

        //    // Update entity(main class)...
        //    existing.UserPosition = model.UserPosition;
        //    existing.Active = model.Active;

        //    // updating group...
        //    var updatedGroup = await _repository.UpdateAsync(existing);

        //    return Result<UserPositions>.SuccessResult(updatedGroup);
        //}

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _repository.DeleteAsync(existing);
            return true;
        }

    }
}
