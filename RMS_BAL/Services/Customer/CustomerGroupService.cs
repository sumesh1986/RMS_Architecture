using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS_BAL.Repository.Interfaces;
using RMS_BAL.Services.Result;
using RMS_Data.Repository.Customer;
using RMS_Data.Service.Interfaces;
using RMS_Models.Models;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.DTO.Customers;


namespace RMS_BAL.Services.Customer
{
    public class CustomerGroupService : ICustomerGroupService
    {
        private readonly ICustomerGroupRepository _repository;

        public CustomerGroupService(ICustomerGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int totalRecords, IEnumerable<CustomerGroupDTO> data)> GetAsync(int page, int pageSize, string? groupName = null)
        {
            var (totalRecords, groups) = await _repository.GetAsync(page, pageSize, groupName);

            var data = groups.Select(g => new CustomerGroupDTO
            {
                SysId = g.SysId,
                GroupName = g.GroupName,
                Active = g.Active
            });

            return (totalRecords, data);
        }

        public async Task<Result<CustomerGroup>> CreateAsync(CustomerGroupDTO model)
        {
            // Validation...
            if (string.IsNullOrWhiteSpace(model.GroupName))
            {
                return Result<CustomerGroup>.FailureResult("Group Name is required.");
            }

            // cheking existing group...
            var existing = await _repository.GetByGroupNameAsync(model.GroupName);
            if (existing is not null || existing != null)
            {
                return Result<CustomerGroup>.FailureResult("Group Name already exists.");
            }

            // mapping DTO to entity(main class)...
            var customerGroup = new CustomerGroup
            {
                GroupName = model.GroupName,
                Active = model.Active,
                InsertedTime = DateTime.Now
            };

            // creating group...
            var createdGroup = await _repository.CreateAsync(customerGroup);

            return Result<CustomerGroup>.SuccessResult(createdGroup);
        }


        public async Task<Result<CustomerGroup>> UpdateAsync(CustomerGroupDTO model)
        {
            // Validation
            if (model.SysId == 0)
            {
                return Result<CustomerGroup>.FailureResult("Group Name should not be empty.");
            }

            // cheking existing group...
            var group = await _repository.GetByGroupNameAsync(model.GroupName);
            if (group != null)
            {
                if (model.Active == group.Active)
                {
                    return Result<CustomerGroup>.FailureResult("Customer Group Name already exists.");
                }
            }

            var existing = await _repository.GetByIdAsync(model.SysId);

            // Update entity(main class)...
            existing.GroupName = model.GroupName;
            existing.Active = model.Active;

            // updating group...
            var updatedGroup = await _repository.UpdateAsync(existing);

            return Result<CustomerGroup>.SuccessResult(updatedGroup);
        }

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
