using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.Customers;


namespace RMS_Data.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<string>> GettitlesAsync();
        Task<IEnumerable<string>>GetgroupsAsync();
        Task<IEnumerable<string>> GettypesAsync();
        Task<IEnumerable<int>> GetpriceAsync();
        Task<IEnumerable<string>> GetdiscountAsync();


        Task<CustomersMain> CreateAsync(CustomersMain CustomersRepomodel);
        //Task<CustomerTitle> CreateAsync(Customer model);
        //Task<CustomerTitle> CreateAsync(CustomerTitle model);
    }
}
