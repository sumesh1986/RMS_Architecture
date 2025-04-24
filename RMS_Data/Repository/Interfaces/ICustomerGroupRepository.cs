using RMS_Models.Models;
using RMS_Models.Models.API_Models.Customers;

namespace RMS_Data.Service.Interfaces
{
    public interface ICustomerGroupRepository
    {
        Task<(int totalRecords, IEnumerable<CustomerGroup>)> GetAsync(int page, int pageSize, string? groupName = null);


        Task<CustomerGroup> CreateAsync(CustomerGroup model);

        Task<CustomerGroup> UpdateAsync(CustomerGroup customerGroup);

        Task<CustomerGroup?> GetByIdAsync(int id);

        Task<CustomerGroup?> GetByGroupNameAsync(string groupName);
        
        Task DeleteAsync(CustomerGroup group);



    }
}
