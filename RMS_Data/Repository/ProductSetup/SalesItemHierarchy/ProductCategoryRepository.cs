using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;

namespace RMS_Data.Repository.ProductSetup.SalesItemHierarchy
{
    public class ProductCategoryRepository: IProductSetupCategoryRepository
    {

        private readonly ApplicationDbContext _db;

        public ProductCategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //public async Task<(int totalRecords, IEnumerable<CategoryViewModel>)> GetAsync(int page, int pageSize, string? groupName)
        //{
        //    IQueryable<CategoryViewModel> query;

        //    if (string.IsNullOrWhiteSpace(groupName) || groupName is null)
        //    {
        //        query = _db.Category.AsQueryable();
        //        //query = _db.Category.Where(c => c.fldisactive);
        //    }
        //    else
        //    {
        //        query = _db.Category.Where(cg => cg.Category!.Contains(groupName));

        //    }

        //    var totalRecords = await query.CountAsync();

        //    var data = await query
        //        .OrderByDescending(cg => cg.SysID) // Sort descending
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .Select(cg => new CategoryViewModel
        //        {
        //            SysID = cg.SysID,
        //            Category = cg.Category,
        //            Active=cg.Active
        //        })
        //        .ToListAsync();


        //    return (totalRecords, data);
        //}

        public async Task<IEnumerable<CategoryViewModel>> GetALLAsync_Repo(string groupName)
        {
            IQueryable<CategoryViewModel> query;

            if (string.IsNullOrWhiteSpace(groupName))
            {
                query = _db.Category.Where(c => c.Active == "Yes");
            }
            else
            {
                query = _db.Category
                    .Where(c => c.Active == "Yes" && c.Category != null && c.Category.Contains(groupName));
            }


            var data = await query
                .OrderByDescending(cg => cg.SysID) // Sort descending

                .Select(cg => new CategoryViewModel
                {
                    SysID = cg.SysID,
                    Category = cg.Category,
                    Active = cg.Active
                })
                .ToListAsync();


            return (data);
        }

        public async Task<CategoryViewModel> CreateAsync(CategoryViewModel model)
        {
            _db.Category.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<CategoryViewModel> UpdateAsync(CategoryViewModel reqConcept)
        {
            _db.Category.Update(reqConcept);
            await _db.SaveChangesAsync();
            return reqConcept;
        }
        //public async Task<CategoryViewModel> DeleteAsync(CategoryViewModel concept_row)
        //{
        //    _db.Category.Update(concept_row);
        //    await _db.SaveChangesAsync();
        //    return concept_row;
        //}
        public async Task DeleteAsync(CategoryViewModel concept_row)
        {
            _db.Category.Remove(concept_row);
            await _db.SaveChangesAsync();
        }
        public async Task<CategoryViewModel?> GetByIdAsync(int id)
        {
            return await _db.Category
                .Where(cg => cg.SysID == id)
                .FirstOrDefaultAsync();
        }
        public async Task<CategoryViewModel?> GetByNameAsync(string Name)
        {
            return await _db.Category.FirstOrDefaultAsync(cg => cg.Category == Name);
        }



        //public async Task<int> GetMaxRefIDAsync()
        //{
        //    return await _db.Category
        //                         .Where(c => !c.fldisdeleted)
        //                         .MaxAsync(c => (int?)c.RefID) ?? 0;
        //}


    }
}
