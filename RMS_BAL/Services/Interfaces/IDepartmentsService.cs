using RMS_BAL.Services.Result;
using RMS_Models.Models.API_Models.Users;
using RMS_Models.Models.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_BAL.Services.Interfaces
{
    public interface IDepartmentsService
    {
        Task<(int totalRecords, IEnumerable<DepartmentsDTO> data)> GetAsync(int page, int pageSize, string? groupName = null);


        Task<Result<Departments>> CreateAsync(DepartmentsDTO model);

        Task<Result<Departments>> UpdateAsync(DepartmentsDTO department);

        Task<bool> DeleteAsync(int id);
    }
}
