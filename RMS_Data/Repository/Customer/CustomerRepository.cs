using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.Customers;

namespace RMS_Data.Repository.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<string>> GettitlesAsync()
        {
            return await _db.CustomerTitles
                .Select(p => p.NameTitle)
                .Distinct()
                .OrderBy(m => m)
                .ToListAsync();
        }


        public async Task<IEnumerable<string>> GetgroupsAsync()
        {
            return await _db.CustomerGroup
                .Select(p => p.GroupName)
                .Distinct()
                .OrderBy(m => m)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GettypesAsync()
        {
            return await _db.CustomerType
                .Select(p => p.NameType)
                .Distinct()
                .OrderBy(m => m)
                .ToListAsync();
        }

        public async Task<IEnumerable<int>> GetpriceAsync()
        {
            return await _db.PriceGroupMaster
                .Select(p => p.PriceGroup)
                .Distinct()
                .OrderBy(m => m)
                .ToListAsync();
        }
        public async Task<IEnumerable<string>> GetdiscountAsync()
        {
            return await _db.DiscountTB
                .Select(p => p.DiscountName)
                .Distinct()
                .OrderBy(m => m)
                .ToListAsync();
        }

    }
}







