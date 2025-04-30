using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.Users;
using RMS_Models.Models;


namespace RMS_Data.Repository.Interfaces
{
    public interface IUserPositionsRepository
    {
        Task<(int totalRecords, IEnumerable<UserPositions>)> GetAsync(int page, int pageSize, string? groupName = null);


        Task<UserPositions> CreateAsync(UserPositions model);

        Task<UserPositions> UpdateAsync(UserPositions customerGroup);

        Task<UserPositions?> GetByIdAsync(int id);

        Task<UserPositions?> GetByGroupNameAsync(string groupName);

        Task DeleteAsync(UserPositions group);
    }
}
