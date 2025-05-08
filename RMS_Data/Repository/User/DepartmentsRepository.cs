using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Data.Repository.User
{
    public class DepartmentsRepository: IDepartmentsRepository
    {
        private readonly ApplicationDbContext _db;

        public DepartmentsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<(int totalRecords, IEnumerable<Departments>)> GetAsync(int page, int pageSize, string? groupName = null)
        {
            IQueryable<Departments> query;

            if (string.IsNullOrWhiteSpace(groupName) || groupName is null)
            {
                query = _db.Department.AsQueryable();
            }
            else
            {
                query = _db.Department.Where(cg => cg.Department.Contains(groupName));
            }

            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderBy(cg => cg.SysId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(cg => new Departments
                {
                    SysId = cg.SysId,
                    Department = cg.Department,
                    Active = cg.Active
                })
                .ToListAsync();

            return (totalRecords, data);

        }




        public async Task<Departments> CreateAsync(Departments model)
        {
            _db.Department.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Departments> UpdateAsync(Departments departments)
        {
            _db.Department.Update(departments);
            await _db.SaveChangesAsync();
            return departments;
        }

        public async Task<Departments?> GetByIdAsync(int id)
        {
            return await _db.Department
                .Where(cg => cg.SysId == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Departments?> GetByGroupNameAsync(string groupName)
        {
            return await _db.Department.FirstOrDefaultAsync(cg => cg.Department == groupName);
        }

        public async Task DeleteAsync(Departments group)
        {
            _db.Department.Remove(group);
            await _db.SaveChangesAsync();
        }
    }
}
