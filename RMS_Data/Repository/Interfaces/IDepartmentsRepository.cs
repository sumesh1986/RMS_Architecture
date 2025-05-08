using RMS_Models.Models.API_Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Data.Repository.Interfaces
{
    public interface IDepartmentsRepository
    {
        Task<(int totalRecords, IEnumerable<Departments>)> GetAsync(int page, int pageSize, string? groupName = null);


        Task<Departments> CreateAsync(Departments model);

        Task<Departments> UpdateAsync(Departments customerGroup);

        Task<Departments?> GetByIdAsync(int id);

        Task<Departments?> GetByGroupNameAsync(string groupName);

        Task DeleteAsync(Departments group);
    }
}
