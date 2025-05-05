using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS_BAL.Repository.Interfaces;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.Result;
using RMS_Data.Repository.Customer;
using RMS_Data.Repository.Interfaces;
using RMS_Data.Service.Interfaces;
using RMS_Models.Models;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.DTO.Customers;

namespace RMS_BAL.Services.Customer
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly ICustomerTypeRepository _repository;

        public CustomerTypeService(ICustomerTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int totalRecords, IEnumerable<CustomerTypeDTO> data)> GetAsync(int page, int pageSize, string? nameType = null)
        {
            var (totalRecords, groups) = await _repository.GetAsync(page, pageSize, nameType);

            var data = groups.Select(g => new CustomerTypeDTO
            {
                SysId = g.SysId,
                NameType = g.NameType,
                Active = g.Active
            });

            return (totalRecords, data);
        }

        public async Task<Result<CustomerType>> CreateAsync(CustomerTypeDTO model)
        {
            // Validation...
            if (string.IsNullOrWhiteSpace(model.NameType))
            {
                return Result<CustomerType>.FailureResult("Group Type is required.");
            }

            // cheking existing group...
            var existing = await _repository.GetByNameTypeAsync(model.NameType);
            if (existing is not null || existing != null)
            {
                return Result<CustomerType>.FailureResult("Group Type already exists.");
            }

            // mapping DTO to entity(main class)...
            var customerType = new CustomerType
            {
                NameType = model.NameType,
                Active = model.Active,
                //InsertedTime = DateTime.Now
            };

            // creating group...
            var createdType = await _repository.CreateAsync(customerType);

            return Result<CustomerType>.SuccessResult(createdType);
        }


        public async Task<Result<CustomerType>> UpdateAsync(CustomerTypeDTO model)
        {
            // Validation
            if (model.SysId == 0)
            {
                return Result<CustomerType>.FailureResult("Group Name should not be empty.");
            }

            // cheking existing group...
            var group = await _repository.GetByNameTypeAsync(model.NameType);
            if (group != null)
            {
                if (model.Active == group.Active)
                {
                    return Result<CustomerType>.FailureResult("Customer Group Name already exists.");
                }
            }

            var existing = await _repository.GetByIdAsync(model.SysId);

            // Update entity(main class)...
            existing.NameType = model.NameType;
            existing.Active = model.Active;

            // updating group...
            var updatedGroup = await _repository.UpdateAsync(existing);

            return Result<CustomerType>.SuccessResult(updatedGroup);
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
