using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.CommonModels;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;

namespace RMS_Data.Repository.Interfaces
{
    public interface ICategoryDropdownRepository
    {
        Task<IEnumerable<CategoryDropdownViewModel>> GetAsync(int Id, string categoryname);
    }
}
