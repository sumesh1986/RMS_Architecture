using RMS_Models.Models;
using RMS_Models.Models.API_Models.Customers;

namespace RMS_BAL.Repository.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CustomerGroup>>GetAllAsync();
    }
}
