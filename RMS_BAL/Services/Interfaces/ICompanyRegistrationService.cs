using RMS_BAL.Services.Result;
using RMS_Models.Models;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.ServiceModels;

namespace RMS_BAL.Services.Interfaces
{
    public interface ICompanyRegistrationService
    {
        Task<Result<RegistrationDTO>> GetAsync(string id);
        Task<Result<Registration>> UpdateAsync(RegistrationDTO model);
    }
}
