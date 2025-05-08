using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.Customers;

namespace RMS_Data.Repository.Interfaces
{
    public interface ICompanyConceptRepository
    {
        Task<(int totalRecords, IEnumerable<CompanyConcept>)> GetAsync(int page, int pageSize, string? groupName = null);


        Task<CompanyConcept> CreateAsync(CompanyConcept model);

        Task<CompanyConcept> UpdateAsync(CompanyConcept conceptGroup);

        Task<CompanyConcept?> GetByIdAsync(int id);

        Task<CompanyConcept?> GetByNameAsync(string conceptName);

        Task DeleteAsync(CompanyConcept conceptgroup);
    }
}
