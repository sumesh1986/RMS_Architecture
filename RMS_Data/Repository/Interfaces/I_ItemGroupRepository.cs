using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_Data.Repository.Interfaces
{
    public interface I_ItemGroupRepository
    {
        //  Task<IEnumerable<ItemGroupViewModel>> GetALLAsyncService(string itemgrouprepo);
        // Task<(int totalRecords, IEnumerable<ItemGroupViewModel>)> GetALLAsyncService(int page, int pageSize, string? itemgrouprepo);

        Task<(int totalRecords, IEnumerable<ItemGroupViewModelDTO>)> GetALLAsyncService(int page, int pageSize, string? groupName = null);



        Task<ItemGroupViewModel> CreateAsync(ItemGroupViewModel itemgroupRepomodel);
        Task<ItemGroupViewModel> UpdateAsync(ItemGroupViewModel itemgroupRepomodel);
        Task<ItemGroupViewModel?> GetByNameAsync(string itemgroupName);
        Task<ItemGroupViewModel?> GetByIdAsync(int id);

        //Task<CategoryViewModel?> DeleteAsync(CategoryViewModel model);
        Task DeleteAsync(ItemGroupViewModel model);
    }
}
