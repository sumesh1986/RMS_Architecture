using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Data.Data;
using RMS_Data.Service.Interfaces;
using RMS_Data.Service;
using RMS_Models.Models;
using RMS_Models.Models.API_Models.Users;
using Microsoft.EntityFrameworkCore;
using Azure;
using RMS_Data.Repository.Interfaces;



namespace RMS_Data.Repository.User
{
    public class UserPositionsRepository:IUserPositionsRepository
    {
        private readonly ApplicationDbContext _db;

        public UserPositionsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<(int totalRecords, IEnumerable<UserPositions>)> GetAsync(int page, int pageSize, string? groupName = null)
        {
            IQueryable<UserPositions> query;

            if (string.IsNullOrWhiteSpace(groupName) || groupName is null)
            {
                query = _db.UserPositions.AsQueryable();
            }
            else
            {
                query = _db.UserPositions.Where(cg => cg.UserPosition.Contains(groupName));
            }

            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderBy(cg => cg.SysId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(cg => new UserPositions
                {
                    SysId = cg.SysId,
                    UserPosition = cg.UserPosition,
                    Active = cg.Active
                })
                .ToListAsync();

            return (totalRecords, data);

        }




        public async Task<UserPositions> CreateAsync(UserPositions model)
        {
            _db.UserPositions.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<UserPositions> UpdateAsync(UserPositions userPositions)
        {
            _db.UserPositions.Update(userPositions);
            await _db.SaveChangesAsync();
            return userPositions;
        }

        public async Task<UserPositions?> GetByIdAsync(int id)
        {
            return await _db.UserPositions
                .Where(cg => cg.SysId == id)
                .FirstOrDefaultAsync();
        }
        public async Task<UserPositions?> GetByGroupNameAsync(string groupName)
        {
            return await _db.UserPositions.FirstOrDefaultAsync(cg => cg.UserPosition == groupName);
        }

        public async Task DeleteAsync(UserPositions group)
        {
            _db.UserPositions.Remove(group);
            await _db.SaveChangesAsync();
        }
    }
}
