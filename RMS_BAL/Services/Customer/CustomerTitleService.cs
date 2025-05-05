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
    public class CustomerTitleService : ICustomerTitleService
    {
        private readonly ICustomerTitleRepository _repository;

        public CustomerTitleService(ICustomerTitleRepository repository)
        {
            _repository = repository;
        }
        public async Task<(int totalRecords, IEnumerable<CustomerTitleDTO> data)> GetAsync(int page, int pageSize, string? nameTitle = null)
        {
            var (totalRecords, groups) = await _repository.GetAsync(page, pageSize, nameTitle);

            var data = groups.Select(g => new CustomerTitleDTO
            {
                SysId = g.SysId,
                NameTitle = g.NameTitle
            
            });

            return (totalRecords, data);
        }
        public async Task<Result<CustomerTitle>> CreateAsync(CustomerTitleDTO model)
        {
            // Validation...
            if (string.IsNullOrWhiteSpace(model.NameTitle))
            {
                return Result<CustomerTitle>.FailureResult("Name Title is required.");
            }

            // cheking existing group...
            var existing = await _repository.GetByNameTitleAsync(model.NameTitle);
            if (existing is not null || existing != null)
            {
                return Result<CustomerTitle>.FailureResult("Name Title already exists.");
            }

            // mapping DTO to entity(main class)...
            var customerTitle = new CustomerTitle
            {
                NameTitle = model.NameTitle,
               
                //InsertedTime = DateTime.Now
            };

            // creating group...
            var createdType = await _repository.CreateAsync(customerTitle);

            return Result<CustomerTitle>.SuccessResult(createdType);
         }


        public async Task<Result<CustomerTitle>> UpdateAsync(CustomerTitleDTO model)
        {
            // Validation
            if (model.SysId == 0)
            {
                return Result<CustomerTitle>.FailureResult("Customer titile should not be empty.");
            }

            // cheking existing group...
            var group = await _repository.GetByNameTitleAsync(model.NameTitle);
            if (group != null)
            {
                if (model.NameTitle == group.NameTitle)
                {
                    return Result<CustomerTitle>.FailureResult("Customer titile Name already exists.");
                }
            }

            var existing = await _repository.GetByIdAsync(model.SysId);

            // Update entity(main class)...
            existing.NameTitle = model.NameTitle;
            //existing.Active = model.Active;

            // updating group...
            var updatedGroup = await _repository.UpdateAsync(existing);

            return Result<CustomerTitle>.SuccessResult(updatedGroup);
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
