using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Data.Data;
using Microsoft.EntityFrameworkCore;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_Data.Repository.ProductSetup.SalesItemHierarchy
{
    public class ItemGroupRepository : I_ItemGroupRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemGroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //public async Task<(int totalRecords, IEnumerable<ItemGroupViewModel>)> GetALLAsyncService(int page, int pageSize, string? groupName = null)
        //{
        //    IQueryable<ItemGroupViewModel> query;

        //    if (string.IsNullOrWhiteSpace(groupName) || groupName is null)
        //    {
        //        query = _db.ItemGroup.AsQueryable();
        //    }
        //    else
        //    {
        //        query = _db.ItemGroup.Where(cg => cg.GroupName!.Contains(groupName));

        //    }

        //    var totalRecords = await query.CountAsync();

        //    var data = await query
        //        .OrderByDescending(cg => cg.SysID) // Sort descending
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .Select(cg => new ItemGroupViewModel
        //        {
        //            SysID = cg.SysID,
        //            GroupName = cg.GroupName,                   
        //            Active = cg.Active
        //        })
        //        .ToListAsync();

        //    return (totalRecords, data);
        //}

      

        public async Task<(int totalRecords, IEnumerable<ItemGroupViewModelDTO>)> GetALLAsyncService(int page, int pageSize, string? groupName = null)
        {
            var query = from ig in _db.ItemGroup
                        join d in _db.Division on ig.DivisionID equals d.SysID
                        where string.IsNullOrEmpty(groupName) || ig.GroupName == groupName
                        select new ItemGroupViewModelDTO
                        {
                            GroupName = ig.GroupName,
                            Active = ig.Active,
                            SysID = ig.SysID,
                            DivisionID = ig.DivisionID,
                            RevenueAC = ig.RevenueAC,
                            DiscountAC = ig.DiscountAC,
                            ExpenseAC = ig.ExpenseAC,
                            HideONPDA = ig.HideONPDA,
                            Modifier = ig.Modifier,
                            ChoosenModifier = ig.ChoosenModifier,
                            Tax1 = ig.Tax1,
                            Tax2 = ig.Tax2,
                            Tax3 = ig.Tax3,
                            Tax4 = ig.Tax4,
                            Municipality = ig.Municipality,
                            ServiceCharge = ig.ServiceCharge,
                            LogicalPrinters = ig.LogicalPrinters,
                            DivisionName = d.Division
                        };

         

            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderByDescending(g => g.SysID)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRecords, data); // Returns a tuple
        }


        public async Task<ItemGroupViewModel?> GetByNameAsync(string Name)
        {
            return await _db.ItemGroup.FirstOrDefaultAsync(cg => cg.GroupName == Name);
        }
        public async Task<ItemGroupViewModel> CreateAsync(ItemGroupViewModel model)
        {
            _db.ItemGroup.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<ItemGroupViewModel> UpdateAsync(ItemGroupViewModel reqItemGroup)
        {
            _db.ItemGroup.Update(reqItemGroup);
            await _db.SaveChangesAsync();
            return reqItemGroup;
        }

        public async Task DeleteAsync(ItemGroupViewModel itemgroup_row)
        {
            _db.ItemGroup.Remove(itemgroup_row);
            await _db.SaveChangesAsync();
        }
        public async Task<ItemGroupViewModel?> GetByIdAsync(int id)
        {
            return await _db.ItemGroup
                .Where(cg => cg.SysID == id)
                .FirstOrDefaultAsync();
        }
    }
}
