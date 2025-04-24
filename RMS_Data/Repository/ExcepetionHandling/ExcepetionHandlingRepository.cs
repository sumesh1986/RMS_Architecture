using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.ServiceModels;

namespace RMS_Data.Repository.ExcpetionHandling
{
    public class ExcepetionHandlingRepository: IExcepetionHandlingRepository
    {
        private readonly ApplicationDbContext _db;
        public ExcepetionHandlingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task LogError(ErrorLog log)
        {
            _db.ErrorLogs.Add(log);
            await _db.SaveChangesAsync();
        }
    }
}
