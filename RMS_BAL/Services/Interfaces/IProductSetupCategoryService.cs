using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_BAL.Services.Result;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_BAL.Services.Interfaces
{
    public interface IProductSetupCategoryService
    {
       
        Task<IEnumerable<CategoryViewModelDTO>> I_GetALLAsyncService(string categoryname);

        Task<Result<CategoryViewModel>> CreateAsync(CategoryViewModelDTO model);

        Task<Result<CategoryViewModel>> UpdateAsync(CategoryViewModelDTO model);

        Task<bool> DeleteAsync(int id);
    }
}
