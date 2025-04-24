using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_BAL.Services.Result;
using RMS_Models.Models;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.DTO.Customers;

namespace RMS_BAL.Repository.Interfaces
{
    public interface ICustomerGroupService
    {
        Task<(int totalRecords, IEnumerable<CustomerGroupDTO> data)> GetAsync(int page, int pageSize, string? groupName = null);


        Task<Result<CustomerGroup>> CreateAsync(CustomerGroupDTO model);

        Task<Result<CustomerGroup>> UpdateAsync(CustomerGroupDTO customerGroup);

        Task<bool> DeleteAsync(int id);


    }

}

