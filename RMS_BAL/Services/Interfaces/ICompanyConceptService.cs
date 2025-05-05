using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_BAL.Services.Result;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.DTO.Customers;

namespace RMS_BAL.Services.Interfaces
{
    public interface ICompanyConceptService
    {
        Task<(int totalRecords, IEnumerable<CompanyConceptDTO> data)> GetAsync(int page, int pageSize, string? groupName = null);


        Task<Result<CompanyConcept>> CreateAsync(CompanyConceptDTO model);

        Task<Result<CompanyConcept>> UpdateAsync(CompanyConceptDTO model);

        Task<bool> DeleteAsync(int id);
    }


}
