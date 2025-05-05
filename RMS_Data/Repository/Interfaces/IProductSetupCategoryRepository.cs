using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;

namespace RMS_Data.Repository.Interfaces
{
    public interface IProductSetupCategoryRepository
    {
        //Task<(int totalRecords, IEnumerable<CategoryViewModel>)> GetAsync(int page, int pageSize, string? groupName = null);

        Task<IEnumerable<CategoryViewModel>> GetALLAsync_Repo(string categoryRepo);

        //Task<int> GetMaxRefIDAsync(); // MUST be declared here
        Task<CategoryViewModel> CreateAsync(CategoryViewModel model);

        Task<CategoryViewModel> UpdateAsync(CategoryViewModel model);

        Task<CategoryViewModel?> GetByIdAsync(int id);

        Task<CategoryViewModel?> GetByNameAsync(string categoryName);

        //Task<CategoryViewModel?> DeleteAsync(CategoryViewModel model);
        Task DeleteAsync(CategoryViewModel model);
      
    }
}
