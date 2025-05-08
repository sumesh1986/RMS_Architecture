//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using RMS_BAL.Services.Interfaces;
//using RMS_Data.Repository.Interfaces;
//using RMS_Data.Service.Interfaces;
//using RMS_Models.Models.API_Models.CommonModels;

//namespace RMS_BAL.Services.Dropdown
//{
//    public class DropdownService : IDropdownCommonServices
//    {
//        private readonly IDropdownCommonRepository _repository;

//        public DropdownService(IDropdownCommonRepository repository)
//        {
//            _repository = repository;
//        }
//        public async Task<IEnumerable<CustomerDropdownViewModel>> GetCustomerAsync(int sysId, string? nametitle)
//        {
//            var result = await _repository.GetCustomerAsync(sysId, nametitle);
//            return result;
//        }
//    }
//}
