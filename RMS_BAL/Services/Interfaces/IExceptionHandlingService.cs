using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.ServiceModels;

namespace RMS_BAL.Services.Interfaces
{
    public interface IExceptionHandlingService
    {
        Task LogError(ErrorLog log);
    }

}
