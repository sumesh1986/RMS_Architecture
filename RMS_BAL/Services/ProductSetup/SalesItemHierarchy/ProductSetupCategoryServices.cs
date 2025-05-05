using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_BAL.Services.Result;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.API_Models.CommonModels;
using RMS_BAL.Services.Interfaces;
using RMS_Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace RMS_BAL.Services.ProductSetup.SalesItemHierarchy
{
    public class ProductSetupCategoryServices: IProductSetupCategoryService
    { 

        private readonly IProductSetupCategoryRepository _repository;

        public ProductSetupCategoryServices(IProductSetupCategoryRepository repository)
        {
            _repository = repository;
        }

        //public async Task<(int totalRecords, IEnumerable<CategoryViewModelDTO> data)> GetAsync(int page, int pageSize, string? groupName = null)
        //{
        //    var (totalRecords, groups) = await _repository.GetAsync(page, pageSize, groupName);

        //    var data = groups.Select(g => new CategoryViewModelDTO
        //    {
        //        SysID = g.SysID,
        //        Category = g.Category,              
        //        Active = g.Active
        //    });

        //    return (totalRecords, data);
        //}

        public async Task<IEnumerable<CategoryViewModelDTO>> I_GetALLAsyncService(string division)
        {
            var groups = await _repository.GetALLAsync_Repo(division);

            var data = groups.Select(g => new CategoryViewModelDTO
            {
                SysID = g.SysID,
                Category = g.Category,
                Active = g.Active
            });

            return (data);
        }

        public async Task<Result<CategoryViewModel>> CreateAsync(CategoryViewModelDTO model)
        {
            // Validation...
            if (string.IsNullOrWhiteSpace(model.Category))
            {
                return Result<CategoryViewModel>.FailureResult("Category Name is required.");
            }

            // cheking existing group...
            var existing = await _repository.GetByNameAsync(model.Category);
            if (existing is not null || existing != null)
            {
                return Result<CategoryViewModel>.FailureResult("Category Name already exists.");
            }

            //int latestRefId = await _repository.GetMaxRefIDAsync();
           


            // mapping DTO to entity(main class)...
            var category = new CategoryViewModel
            {
                Category = model.Category,
                Active = model.Active
                //fldmodifiedno=0,
                //RefID = latestRefId + 1

            };
            //category.SetInsert("admin");
            // creating group...
            var createdGroup = await _repository.CreateAsync(category);

            return Result<CategoryViewModel>.SuccessResult(createdGroup);
        }


        public async Task<Result<CategoryViewModel>> UpdateAsync(CategoryViewModelDTO model)
        {
            // Validation
            if (model.SysID == 0)
            {
                return Result<CategoryViewModel>.ValidationResult("Category ID should not be empty.");
            }
            if (string.IsNullOrWhiteSpace(model.Category))
            {
                return Result<CategoryViewModel>.ValidationResult("Category Name should not be empty.");
            }

            // 2. Check if the new Category name already exists
            var existingGroup = await _repository.GetByNameAsync(model.Category!);

            if (existingGroup != null && existingGroup.Category == model.Category)
            {
                return Result<CategoryViewModel>.ValidationResult("Category Name already Exists.");
            }
            // cheking existing concept name...

            var group = await _repository.GetByNameAsync(model.Category!);

            if (group != null)
            {
                if (model.Active == group.Active)
                {
                    return Result<CategoryViewModel>.ValidationResult("Category Name already Exists.");
                }
            }

            var existing = await _repository.GetByIdAsync(model.SysID);

            // Update entity(main class)...
            existing.Category = model.Category;
            existing.Active = model.Active;
            //existing.UpdatedAt = DateTime.Now;
            // updating group...
            var updatedGroup = await _repository.UpdateAsync(existing);

            return Result<CategoryViewModel>.SuccessResult(updatedGroup);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _repository.DeleteAsync(existing);
            return true;
        }


        //public async Task<Result<CategoryViewModel>> UpdateAsync(CategoryViewModelDTO model)
        //{
        //    // 1. Validation
        //    if (model.SysID == 0)
        //    {
        //        return Result<CategoryViewModel>.ValidationResult("Category ID should not be empty.");
        //    }

        //    if (string.IsNullOrWhiteSpace(model.Category))
        //    {
        //        return Result<CategoryViewModel>.ValidationResult("Category Name should not be empty.");
        //    }

        //    // 2. Check if the new Category name already exists
        //    var existingGroup = await _repository.GetByNameAsync(model.Category!);

        //    if (existingGroup != null && existingGroup.Category == model.Category)
        //    {
        //        return Result<CategoryViewModel>.ValidationResult("Category Name already Exists.");
        //    }

        //    // 3. Find the old active record by ID
        //    var oldCategory = await _repository.GetByIdAsync(model.SysID);

        //    if (oldCategory == null)
        //    {
        //        return Result<CategoryViewModel>.FailureResult("Category not found.");
        //    }
        //   // string userName = "test_admin";

        //    // 4. Deactivate and soft-delete the old record
        //    /// oldCategory.fldisactive = false;

        //    // mapping DTO to entity(main class)...
        //    var category = new CategoryViewModel
        //    {
        //        Category = model.Category,
        //        Active = model.Active
        //    };

        //    var updatedCategory = await _repository.UpdateAsync(oldCategory); // Update old record
        //    return Result<CategoryViewModel>.SuccessResult(updatedCategory);

        //    // //var old_Ref_ID = await _repository.GetMaxRefIDAsync();

        //    // 5. Insert a new record with updated data
        //    //var newCategory = new CategoryViewModel
        //    //{
        //    //    Category = model.Category,
        //    //    Status = model.Status,
        //    //    fldinsertedby = oldCategory.fldinsertedby,
        //    //    fldinserteddatetime = oldCategory.fldinserteddatetime,
        //    //    fldmodifiedno= (oldCategory.fldmodifiedno ?? 0) + 1,
        //    //    RefID= oldCategory.RefID,
        //    //    fldmodifieddate = DateTime.Now,
        //    //    fldmodifiedby= userName,
        //    //    fldisactive = true
        //    //};
        //    //newCategory.SetModified(userName);
        //    //var createdCategory = await _repository.CreateAsync(newCategory);

        //    //// 6. Return the newly created record
        //    //return Result<CategoryViewModel>.SuccessResult(createdCategory);
        //}

     
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var existing = await _repository.GetByIdAsync(id);
        //    if (existing == null)
        //        return false;
        //    string userName = "test_admin";
        //    existing.SetDeleted(userName);
        //    existing.fldisactive = false;
        //    await _repository.DeleteAsync(existing); // Update record          
        //    return true;
        //}
    }
}
