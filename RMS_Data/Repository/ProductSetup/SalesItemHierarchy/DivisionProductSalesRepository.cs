using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;

namespace RMS_Data.Repository.ProductSetup.SalesItemHierarchy
{
    public class DivisionProductSalesRepository : IDivisionRepository
    {
        private readonly ApplicationDbContext _db;

        public DivisionProductSalesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<DivisionViewModel>> GetAsyncService(string groupName)
        {
            IQueryable<DivisionViewModel> query;

            if (string.IsNullOrWhiteSpace(groupName) || groupName is null)
            {
                query = _db.Division.AsQueryable();
                //query = _db.Category.Where(c => c.fldisactive);
            }
            else
            {
                query = _db.Division.Where(cg => cg.Division!.Contains(groupName));

            }


            var data = await query
                .OrderByDescending(cg => cg.SysID) // Sort descending
               
                .Select(cg => new DivisionViewModel
                {
                    SysID = cg.SysID,
                    Division = cg.Division                  
                })
                .ToListAsync();


            return (data);
        }


        public async Task<DivisionViewModel?> GetByNameAsync(string Name)
        {
            return await _db.Division.FirstOrDefaultAsync(cg => cg.Division == Name);
        }
        public async Task<DivisionViewModel> CreateAsync(DivisionViewModel model)
        {
            _db.Division.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<DivisionViewModel> UpdateAsync(DivisionViewModel reqDivsion)
        {
            _db.Division.Update(reqDivsion);
            await _db.SaveChangesAsync();
            return reqDivsion;
        }

        public async Task DeleteAsync(DivisionViewModel division_row)
        {
            _db.Division.Remove(division_row);
            await _db.SaveChangesAsync();
        }
        public async Task<DivisionViewModel?> GetByIdAsync(int id)
        {
            return await _db.Division
                .Where(cg => cg.SysID == id)
                .FirstOrDefaultAsync();
        }
    }
}
