using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_BAL.Services.Result;
using RMS_Models.Models;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.DTO.Customers;

namespace RMS_BAL.Services.Interfaces
{
   public interface ICustomerTypeService
    {

        Task<(int totalRecords, IEnumerable<CustomerTypeDTO> data)> GetAsync(int page, int pageSize, string? NameType = null);


        Task<Result<CustomerType>> CreateAsync(CustomerTypeDTO model);

        Task<Result<CustomerType>> UpdateAsync(CustomerTypeDTO CustomerType);

        Task<bool> DeleteAsync(int id);
        //Task CreateAsync(CustomerTypeDTO model);
    }
}
