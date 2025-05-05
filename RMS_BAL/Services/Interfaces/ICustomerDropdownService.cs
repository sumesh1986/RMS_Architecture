using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.CommonModels;

namespace RMS_BAL.Services.Interfaces
{
   public  interface ICustomerDropdownService
    {

        Task<(int totalRecords, IEnumerable<CustomerDropdownViewModel> data)> GetCustomerAsync(int sysId, string? nametitle);

    }
}





