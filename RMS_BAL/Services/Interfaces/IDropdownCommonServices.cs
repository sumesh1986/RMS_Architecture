using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.CommonModels;
<<<<<<< HEAD
=======
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;
>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274

namespace RMS_BAL.Services.Interfaces
{
    public interface IDropdownCommonServices
    {
<<<<<<< HEAD

        Task<IEnumerable<CustomerDropdownViewModel>> GetustomerAsync(int sysId, string nametitle);
=======
        Task<IEnumerable<CategoryDropdownViewModel>> GetProductSalesCategoryAsync(int catId, string categoryname, int divsionId, string divisionName);

>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274
    }
}
