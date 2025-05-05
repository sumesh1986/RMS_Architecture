using RMS_BAL.Services.Result;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.DTO.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_BAL.Services.Interfaces
{
    public interface ICustomerTitleService
    {
        Task<(int totalRecords, IEnumerable<CustomerTitleDTO> data)> GetAsync(int page, int pageSize, string? NameTitle = null);


        Task<Result<CustomerTitle>> CreateAsync(CustomerTitleDTO model);

        Task<Result<CustomerTitle>> UpdateAsync(CustomerTitleDTO CustomerTitle);

        Task<bool> DeleteAsync(int id);


    }
}












