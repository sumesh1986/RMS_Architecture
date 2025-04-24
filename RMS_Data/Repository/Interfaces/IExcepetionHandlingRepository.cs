using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models;
using RMS_Models.Models.ServiceModels;

namespace RMS_Data.Repository.Interfaces
{
    public interface IExcepetionHandlingRepository
    {
        Task LogError(ErrorLog log);
    }
}
