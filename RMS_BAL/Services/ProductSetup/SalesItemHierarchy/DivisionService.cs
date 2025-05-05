using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.Result;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_BAL.Services.ProductSetup.SalesItemHierarchy
{
    public class DivisionService: IDivisionService
    {
        private readonly IDivisionRepository _repository;

        public DivisionService(IDivisionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DivisionViewModelDTO>> GetAsyncService(string division)
        {
            var groups = await _repository.GetAsyncService(division);

            var data = groups.Select(g => new DivisionViewModelDTO
            {
                SysID = g.SysID,
                CategoryID = g.CategoryID,
                Division=g.Division,
                Active = g.Active
            });

            return (data);
        }

        public async Task<Result<DivisionViewModel>> CreateAsync(DivisionViewModelDTO model)
        {
            // Validation...
            if (string.IsNullOrWhiteSpace(model.Division))
            {
                return Result<DivisionViewModel>.FailureResult("Division Name is required.");
            }

            // cheking existing group...
            var existing = await _repository.GetByNameAsync(model.Division);
            if (existing is not null || existing != null)
            {
                return Result<DivisionViewModel>.FailureResult("Division Name already exists.");
            }
         
            // mapping DTO to entity(main class)...
            var division = new DivisionViewModel
            {
                Division = model.Division,
                CategoryID=model.CategoryID,
                Active = model.Active
            };
          
            // creating group...
            var createdGroup = await _repository.CreateAsync(division);

            return Result<DivisionViewModel>.SuccessResult(createdGroup);
        }

        public async Task<Result<DivisionViewModel>> UpdateAsync(DivisionViewModelDTO model)
        {
            // Validation
            if (model.SysID == 0)
            {
                return Result<DivisionViewModel>.ValidationResult("Division ID should not be empty.");
            }
            if (string.IsNullOrWhiteSpace(model.Division))
            {
                return Result<DivisionViewModel>.ValidationResult("Division Name should not be empty.");
            }

            // 2. Check if the new Category name already exists
            var existingGroup = await _repository.GetByNameAsync(model.Division!);

            if (existingGroup != null && existingGroup.Division == model.Division)
            {
                return Result<DivisionViewModel>.ValidationResult("Division Name already Exists.");
            }
            // cheking existing concept name...

            var group = await _repository.GetByNameAsync(model.Division!);

            if (group != null)
            {
                if (model.Active == group.Active)
                {
                    return Result<DivisionViewModel>.ValidationResult("Division Name already Exists.");
                }
            }

            var existing = await _repository.GetByIdAsync(model.SysID);

            // Update entity(main class)...
            existing.Division = model.Division;
           
            //existing.UpdatedAt = DateTime.Now;
            // updating group...
            var updatedGroup = await _repository.UpdateAsync(existing);

            return Result<DivisionViewModel>.SuccessResult(updatedGroup);
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
