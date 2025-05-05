using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;
using RMS_Data.Service.Interfaces;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.Customers;

namespace RMS_Data.Repository.Company
{
    public class CompanyConceptRepository: ICompanyConceptRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyConceptRepository(ApplicationDbContext db)
        {
            _db= db;
        }

        public async Task<(int totalRecords, IEnumerable<CompanyConcept>)> GetAsync(int page, int pageSize, string? groupName = null)
        {
            IQueryable<CompanyConcept> query;

            if (string.IsNullOrWhiteSpace(groupName) || groupName is null)
            {
                query = _db.concept.AsQueryable();
            }
            else
            {              
                query = _db.concept.Where(cg => cg.Name!.Contains(groupName)|| cg.ListofConcept!.Contains(groupName));

            }

            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderByDescending(cg => cg.Id) // Sort descending
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(cg => new CompanyConcept
                {
                     Id= cg.Id,
                    Name = cg.Name,
                    ListofConcept=cg.ListofConcept,
                    Status = cg.Status
                })
                .ToListAsync();

            return (totalRecords, data);
        }

        public async Task<CompanyConcept> CreateAsync(CompanyConcept model)
        {
            _db.concept.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<CompanyConcept> UpdateAsync(CompanyConcept reqConcept)
        {
            _db.concept.Update(reqConcept);
            await _db.SaveChangesAsync();
            return reqConcept;
        }

        public async Task DeleteAsync(CompanyConcept concept_row)
        {
            _db.concept.Remove(concept_row);
            await _db.SaveChangesAsync();

        }
        public async Task<CompanyConcept?> GetByIdAsync(int id)
        {
            return await _db.concept
                .Where(cg => cg.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<CompanyConcept?> GetByNameAsync(string Name)
        {
            return await _db.concept.FirstOrDefaultAsync(cg => cg.Name == Name);
        }

       
    }
}
