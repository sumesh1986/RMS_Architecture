using Microsoft.Extensions.Logging;
using RMS_BAL.Services.Interfaces;
using RMS_Data.Repository.ExcpetionHandling;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.ServiceModels;


namespace RMS_BAL.Services.ExceptionHandlingService
{
    public class ExceptionHandlingService : IExceptionHandlingService
    {
        private readonly IExcepetionHandlingRepository _repo;

        public ExceptionHandlingService(IExcepetionHandlingRepository repo)
        {
            _repo = repo;
        }

        public async Task LogError(ErrorLog log)
        {
            await _repo.LogError(log);
        }
    }
}
