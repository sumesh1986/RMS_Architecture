using RMS_Models.Models.API_Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models;

namespace RMS_Data.Repository.Interfaces
{
     public  interface ICustomerTitleRepository
    {

        Task<(int totalRecords, IEnumerable<CustomerTitle>)> GetAsync(int page, int pageSize, string? NameTitle = null);


        Task<CustomerTitle> CreateAsync(CustomerTitle model);

        Task<CustomerTitle> UpdateAsync(CustomerTitle CustomerTitle);

        Task<CustomerTitle?> GetByIdAsync(int id);

        Task<CustomerTitle?> GetByNameTitleAsync(string NameTitle);

        Task DeleteAsync(CustomerTitle group);
    }
}
