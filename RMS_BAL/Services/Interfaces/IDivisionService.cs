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
    public interface IDivisionService
    {
        Task<IEnumerable<DivisionViewModelDTO>> GetAsyncService(string divisionname);


        Task<Result<DivisionViewModel>> CreateAsync(DivisionViewModelDTO model);

        Task<Result<DivisionViewModel>> UpdateAsync(DivisionViewModelDTO model);

        Task<bool> DeleteAsync(int id);
    }
}
