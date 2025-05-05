using RMS_Models.Models.API_Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models;

namespace RMS_Data.Repository.Interfaces
{
   public interface ICustomerTypeRepository
    {
        Task<(int totalRecords, IEnumerable<CustomerType>)> GetAsync(int page, int pageSize, string? NameType = null);


        Task<CustomerType> CreateAsync(CustomerType model);

        Task<CustomerType> UpdateAsync(CustomerType CustomerType);

        Task<CustomerType?> GetByIdAsync(int id);

        Task<CustomerType?> GetByNameTypeAsync(string NameType);

        Task DeleteAsync(CustomerType group);
    }
}
