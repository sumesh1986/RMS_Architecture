using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_BAL.Services.Result;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_BAL.Services.Interfaces
{
    public interface I_ItemGroupService
    {
        //Task<IEnumerable<ItemGroupViewModelDTO>> GetALLAsyncService(string groupName);
        Task<(int totalRecords, IEnumerable<ItemGroupViewModelDTO> data)> GetALLAsyncService(int page, int pageSize, string? groupName);
        Task<Result<ItemGroupViewModel>> CreateAsync(ItemGroupViewModelDTO model);

        Task<Result<ItemGroupViewModel>> UpdateAsync(ItemGroupViewModelDTO model);

        Task<bool> DeleteAsync(int id);
    }
}
