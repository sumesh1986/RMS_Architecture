using RMS_Models.Models;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.ServiceModels;

namespace RMS_Data.Repository.Interfaces
{
    public interface ICompanyRegistrationRepository
    {
        Task<Registration> GetAsync(string id);
        Task<Registration> UpdateAsync(Registration company);
        Task<Registration?> GetByRegNumberAsync(string? tenantid);
    }
}
