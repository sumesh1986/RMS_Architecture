//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;
//using Microsoft.EntityFrameworkCore;
//using RMS_Data.Data;
//using RMS_Data.Repository.Interfaces;
//using RMS_Models.Models.API_Models.CommonModels;

//namespace RMS_Data.Repository.Dropdown
//{
//   public  class DropdownRepository : IDropdownCommonRepository
//    {

//        private readonly ApplicationDbContext _db;
//        public DropdownRepository(ApplicationDbContext db)
//        {
//            _db = db;
//        }
//        public async Task<IEnumerable<CustomerDropdownViewModel> GetCustomerAsync(int sysId, string? nametitle)
//        {
//            var query = _db.CustomerTitles.AsQueryable();

//            if (sysId > 0)
//            {
//                query = query.Where(c => c.SysID == sysId);
//            }

//            if (!string.IsNullOrEmpty(nametitle))
//            {
//                query = query.Where(c => c.NameTitle.Contains(nametitle));
//            }

//            var result = await query
//                .Select(c => new CustomerDropdownViewModel
//                {
//                    ID = c.SysID,
//                    Name = c.NameTitle
//                })
//                .ToListAsync();

//            return result;
//        }
//    }
//}



