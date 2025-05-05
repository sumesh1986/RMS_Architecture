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
   public class CustomerTypeRepository : ICustomerTypeRepository
    {


        private readonly ApplicationDbContext _db;

        public CustomerTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<(int totalRecords, IEnumerable<CustomerType>)> GetAsync(int page, int pageSize, string? NameType = null)
        {
            IQueryable<CustomerType> query;

            if (string.IsNullOrWhiteSpace(NameType) || NameType is null)
            {
                //query = (IQueryable<RMS_Models.Models.API_Models.Customers.CustomerType>)_db.CustomerType.AsQueryable();
                query = _db.CustomerType.AsQueryable();
            }
            else
            {
                query = _db.CustomerType.Where(cg => cg.NameType.Contains(NameType));
            }

            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderBy(cg => cg.SysId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(cg => new CustomerType
                {
                    SysId = cg.SysId,
                    NameType = cg.NameType,
                    Active = cg.Active
                })
                .ToListAsync();

            return (totalRecords, data);
        }
        public async Task<CustomerType> CreateAsync(CustomerType model)
        {
            _db.CustomerType.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<CustomerType> UpdateAsync(CustomerType CustomerType)
        {
            _db.CustomerType.Update(CustomerType);
            await _db.SaveChangesAsync();
            return CustomerType;
        }

        public async Task<CustomerType?> GetByIdAsync(int id)
        {
            return await _db.CustomerType
                .Where(cg => cg.SysId == id)
                .FirstOrDefaultAsync();
        }
        public async Task<CustomerType?> GetByNameTypeAsync(string nameType)
        {
            return await _db.CustomerType.FirstOrDefaultAsync(cg => cg.NameType == nameType);
        }

        public async Task DeleteAsync(CustomerType group)
        {
            _db.CustomerType.Remove(group);
            await _db.SaveChangesAsync();
        }
    }
}


//public async Task<CustomerGroup?> GetByGroupNameAsync(string groupName)
//{
//    return await _db.CustomerGroups.FirstOrDefaultAsync(cg => cg.GroupName == groupName);
//}
