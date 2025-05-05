using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.CommonModels;

namespace RMS_Data.Repository.Interfaces
{
    public interface IDropdownCommonRepository
    {
<<<<<<< HEAD

        Task<IEnumerable<CustomerDropdownViewModel>> GetCustomerAsync(int sysId, string? nametitle);
=======
        Task<IEnumerable<CategoryDropdownViewModel>> GetProductSalesCategoryAsync(int catId, string? categoryname, int divsionId, string? divisionName);

>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274
    }
}
