using RMS_Data.Data;
using RMS_Data.Service.Interfaces;
using RMS_Models.Models;
using Microsoft.EntityFrameworkCore;
using RMS_Models.Models.API_Models.Customers;
using Azure;

namespace RMS_Data.Repository.Customer
{
    public class CustomerGroupRepository : ICustomerGroupRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerGroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<(int totalRecords, IEnumerable<CustomerGroup>)> GetAsync(int page, int pageSize, string? groupName = null)
        {
            IQueryable<CustomerGroup> query;

            if (string.IsNullOrWhiteSpace(groupName) || groupName is null)
            {
                query = _db.CustomerGroups.AsQueryable();
            }
            else
            {
                query = _db.CustomerGroups.Where(cg => cg.GroupName.Contains(groupName));
            }

            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderBy(cg => cg.SysId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(cg => new CustomerGroup
                {
                    SysId = cg.SysId,
                    GroupName = cg.GroupName,
                    Active = cg.Active
                })
                .ToListAsync();

            return (totalRecords, data);
        }




        public async Task<CustomerGroup> CreateAsync(CustomerGroup model)
        {
            _db.CustomerGroups.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<CustomerGroup> UpdateAsync(CustomerGroup customerGroup)
        {
            _db.CustomerGroups.Update(customerGroup);
            await _db.SaveChangesAsync();
            return customerGroup;
        }

        public async Task<CustomerGroup?> GetByIdAsync(int id)
        {
            return await _db.CustomerGroups
                .Where(cg => cg.SysId == id)
                .FirstOrDefaultAsync();
        }
        public async Task<CustomerGroup?> GetByGroupNameAsync(string groupName)
        {
            return await _db.CustomerGroups.FirstOrDefaultAsync(cg => cg.GroupName == groupName);
        }

        public async Task DeleteAsync(CustomerGroup group)
        {
            _db.CustomerGroups.Remove(group);
            await _db.SaveChangesAsync();
        }


    }
}
