using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;

using RMS_Data.Service.Interfaces;
using RMS_Models.Models;

using RMS_Models.Models.API_Models.Customers;
using Azure;
using System.Security.AccessControl;
using RMS_Data.Repository.Interfaces;




namespace RMS_Data.Repository.Customer
{
   public class CustomerTitleRepository : ICustomerTitleRepository
    {

        private readonly ApplicationDbContext _db;

        public CustomerTitleRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<(int totalRecords, IEnumerable<CustomerTitle>)> GetAsync(int page, int pageSize, string? NameTitle = null)
        {
            IQueryable<CustomerTitle> query;

            if (string.IsNullOrWhiteSpace(NameTitle) || NameTitle is null)
            {
                //query = (IQueryable<RMS_Models.Models.API_Models.Customers.CustomerType>)_db.CustomerType.AsQueryable();
                query = _db.CustomerTitles.AsQueryable();
            }
            else
            {
                query = _db.CustomerTitles.Where(cg => cg.NameTitle.Contains(NameTitle));
            }

            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderBy(cg => cg.SysId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(cg => new CustomerTitle
                {
                    SysId = cg.SysId,
                    NameTitle = cg.NameTitle

                })
                .ToListAsync();

            return (totalRecords, data);
        }


        public async Task<CustomerTitle> CreateAsync(CustomerTitle model)
        {
            _db.CustomerTitles.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }
        public async Task<CustomerTitle> UpdateAsync(CustomerTitle CustomerTitle)
        {
            _db.CustomerTitles.Update(CustomerTitle);
            await _db.SaveChangesAsync();
            return CustomerTitle;
        }

        public async Task<CustomerTitle?> GetByIdAsync(int id)
        {
            return await _db.CustomerTitles
                .Where(cg => cg.SysId == id)
                .FirstOrDefaultAsync();
        }
        public async Task<CustomerTitle?> GetByNameTitleAsync(string nameTitle)
        {
            return await _db.CustomerTitles.FirstOrDefaultAsync(cg => cg.NameTitle == nameTitle);
        }

        public async Task DeleteAsync(CustomerTitle group)
        {
            _db.CustomerTitles.Remove(group);
            await _db.SaveChangesAsync();
        }
    }
}
