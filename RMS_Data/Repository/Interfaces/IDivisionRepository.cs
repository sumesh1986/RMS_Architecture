using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;

namespace RMS_Data.Repository.Interfaces
{
    public interface IDivisionRepository
    {
        Task<IEnumerable<DivisionViewModel>> GetAsyncService(string divsionrepo);


        Task<DivisionViewModel> CreateAsync(DivisionViewModel model);

        Task<DivisionViewModel> UpdateAsync(DivisionViewModel model);
        Task<DivisionViewModel?> GetByNameAsync(string divisionName);


        Task<DivisionViewModel?> GetByIdAsync(int id);
      
        //Task<CategoryViewModel?> DeleteAsync(CategoryViewModel model);
        Task DeleteAsync(DivisionViewModel model);
    }
}
