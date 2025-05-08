using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_BAL.Services.Result;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.DTO.Customers;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_BAL.Services.Interfaces
{
    public interface ICustomerService
    {

        Task<IEnumerable<string>> GettitlesAsync();
        Task<IEnumerable<string>> GetgroupsAsync();
        Task<IEnumerable<string>> GettypesAsync();
        Task<IEnumerable<int>> GetpriceAsync();
        Task<IEnumerable<string>> GetdiscountAsync();


        Task<Result<CustomersMain>> CreateAsync(CustomersMainDTO model);



    }
}

