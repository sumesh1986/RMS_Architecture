using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.CommonModels;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_BAL.Services.Interfaces
{
    public interface IDropdownCommonServices
    {
        Task<IEnumerable<CategoryDropdownViewModel>> GetProductSalesCategoryAsync(int catId, string categoryname, int divsionId, string divisionName);

    }
}
