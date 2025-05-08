using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.Result;
using RMS_Data.Repository.Interfaces;
using RMS_Data.Service.Interfaces;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.DTO.Customers;

namespace RMS_BAL.Services.Company
{
    public class CompanyConceptService: ICompanyConceptService
    {
        private readonly ICompanyConceptRepository _repository;

        public CompanyConceptService(ICompanyConceptRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int totalRecords, IEnumerable<CompanyConceptDTO> data)> GetAsync(int page, int pageSize, string? groupName = null)
        {
            var (totalRecords, groups) = await _repository.GetAsync(page, pageSize, groupName);

            var data = groups.Select(g => new CompanyConceptDTO
            {
                Id = g.Id,
                Name=g.Name,
                ListofConcept = g.ListofConcept,
                Status = g.Status
            });

            return (totalRecords, data);
        }


        public async Task<Result<CompanyConcept>> CreateAsync(CompanyConceptDTO model)
        {
            // Validation...
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return Result<CompanyConcept>.FailureResult("Group Name is required.");
            }

            // cheking existing group...
            var existing = await _repository.GetByNameAsync(model.Name);
            if (existing is not null || existing != null)
            {
                return Result<CompanyConcept>.FailureResult("Concept Name already exists.");
            }

            // mapping DTO to entity(main class)...
            var concept = new CompanyConcept
            {
                Name = model.Name,
                ListofConcept = model.ListofConcept,
                Status=model.Status,
                CreatedAt = DateTime.Now
            };

            // creating group...
            var createdGroup = await _repository.CreateAsync(concept);

            return Result<CompanyConcept>.SuccessResult(createdGroup);
        }


        public async Task<Result<CompanyConcept>> UpdateAsync(CompanyConceptDTO model)
        {
            // Validation
            if (model.Id == 0)
            {
                return Result<CompanyConcept>.ValidationResult("Concept Name should not be empty.");
            }

            // cheking existing concept name...
         
            var group = await _repository.GetByNameAsync(model.Name!);

            if (group != null)
            {
                if (model.Status == group.Status)
                {
                    return Result<CompanyConcept>.ValidationResult("Concept Name already Exists.");
                }
            }

            var existing = await _repository.GetByIdAsync(model.Id);

            // Update entity(main class)...
            existing.Name = model.Name;
            existing.ListofConcept = model.ListofConcept;
            existing.UpdatedAt = DateTime.Now;
            // updating group...
            var updatedGroup = await _repository.UpdateAsync(existing);

            return Result<CompanyConcept>.SuccessResult(updatedGroup);
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
