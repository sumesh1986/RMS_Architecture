﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using RMS_Models.Models.API_Models.CommonModels;

//namespace RMS_BAL.Services.Interfaces
//{
//   public interface ICategoryDropdownService
//    {
//        Task<(int totalRecords, IEnumerable<CategoryDropdownViewModel> data)> GetCategoryAsync(int Id, string? NameTitle);

//    }
//}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.CommonModels;
using RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy;

namespace RMS_BAL.Services.Interfaces
{
    public interface ICategoryDropdownService
    {
        Task<(int totalRecords, IEnumerable<CategoryDropdownViewModel> data)> GetCategoryAsync(int Id, string? categoryname);
    }
}
