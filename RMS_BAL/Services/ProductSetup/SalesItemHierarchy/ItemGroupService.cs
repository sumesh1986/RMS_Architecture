using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.Result;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_BAL.Services.ProductSetup.SalesItemHierarchy
{
    public class ItemGroupService : I_ItemGroupService
    
    {
        private readonly I_ItemGroupRepository _repository;

        public ItemGroupService(I_ItemGroupRepository repository)
        {
            _repository = repository;
        }


        public async Task<(int totalRecords, IEnumerable<ItemGroupViewModelDTO> data)> GetALLAsyncService(int page, int pageSize, string? groupName = null)
        {
            var (totalRecords, groups) = await _repository.GetALLAsyncService(page, pageSize, groupName);

            //var data = groups.Select(g => new ItemGroupViewModelDTO
            //{
            //    SysID = g.SysID,
            //    GroupName = g.GroupName,               
            //    Active = g.Active
            //});

            return (totalRecords, groups);
        }



        public async Task<Result<ItemGroupViewModel>> CreateAsync(ItemGroupViewModelDTO model)
        {
            // Validation...
            if (string.IsNullOrWhiteSpace(model.GroupName))
            {
                return Result<ItemGroupViewModel>.FailureResult("Item Group Name is required.");
            }

            // cheking existing group...
            var existing = await _repository.GetByNameAsync(model.GroupName);
            if (existing is not null || existing != null)
            {
                return Result<ItemGroupViewModel>.FailureResult("Item Group Name already exists.");
            }

            // mapping DTO to entity(main class)...
            var itemgroup = new ItemGroupViewModel
            {
                GroupName = model.GroupName,
                DivisionID = model.DivisionID,                
                Active = model.Active,
                RevenueAC=model.RevenueAC,
                DiscountAC=model.DiscountAC,
                ExpenseAC=model.ExpenseAC,
                Tax1=model.Tax1,
                Tax2=model.Tax2,
                Tax3=model.Tax3,
                Tax4=model.Tax4,
                Municipality=model.Municipality,
                ServiceCharge=model.ServiceCharge,
                HideONPDA= model.HideONPDA,
                Modifier=model.Modifier,
                ChoosenModifier=model.ChoosenModifier
            };

            // creating group...
            var itemgroupcreated = await _repository.CreateAsync(itemgroup);

            return Result<ItemGroupViewModel>.SuccessResult(itemgroupcreated);
        }

        public async Task<Result<ItemGroupViewModel>> UpdateAsync(ItemGroupViewModelDTO model)
        {
            // Validation
            if (model.SysID == 0)
            {
                return Result<ItemGroupViewModel>.ValidationResult("GroupName ID should not be empty.");
            }
            if (string.IsNullOrWhiteSpace(model.GroupName))
            {
                return Result<ItemGroupViewModel>.ValidationResult("GroupName Name should not be empty.");
            }

            // 2. Check if the new GroupName name already exists    // Check for duplicate name (excluding same SysID)
            var existingGroup = await _repository.GetByNameAsync(model.GroupName!);

            if (existingGroup != null && existingGroup.GroupName == model.GroupName)
            {
                return Result<ItemGroupViewModel>.ValidationResult("GroupName Name already Exists.");
            }
         

            // Load existing entity
            var existing = await _repository.GetByIdAsync(model.SysID);

           
            // ✅ Update all relevant fields
            existing.GroupName = model.GroupName;
            existing.DivisionID = model.DivisionID;
            existing.Tax1 = model.Tax1;
            existing.Tax2 = model.Tax2;
            existing.Tax3 = model.Tax3;
            existing.Tax4 = model.Tax4;
            existing.Active = model.Active;
            existing.RevenueAC = model.RevenueAC;
            existing.DiscountAC = model.DiscountAC;
            existing.ExpenseAC = model.ExpenseAC;
            existing.Municipality = model.Municipality;
            existing.ServiceCharge = model.ServiceCharge;
            existing.HideONPDA = model.HideONPDA;
            existing.Modifier = model.Modifier;
            existing.ChoosenModifier = model.ChoosenModifier;

            //existing.UpdatedAt = DateTime.Now;
            // updating group...
            var updatedGroup = await _repository.UpdateAsync(existing);

            return Result<ItemGroupViewModel>.SuccessResult(updatedGroup);
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
