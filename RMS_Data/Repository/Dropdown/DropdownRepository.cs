<<<<<<< HEAD
﻿//using System;
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



=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.CommonModels;

namespace RMS_Data.Repository.Dropdown
{
    public class DropdownRepository : IDropdownCommonRepository
    {
        private readonly ApplicationDbContext _db;
        public DropdownRepository(ApplicationDbContext db)
        {
            _db = db; 
        }

        //GetProductSalesCategoryAsync model...
        public async Task<IEnumerable<CategoryDropdownViewModel>> GetProductSalesCategoryAsync(int catId, string? categoryname, int divsionId, string? divisionName)
        {

            // Case 1: category Load all
            if (catId == 0 && divsionId == 0)
            {
                var allCategories = await _db.Category//category table name
                    .Where(c => c.SysID == catId || catId == 0)
                    .Select(c => new CategoryDropdownViewModel
                    {
                        ID = c.SysID,
                        Name = c.Category
                    })
                    .ToListAsync();

                return allCategories;
            }

            // Case 2: Load divisions based on category
            else if (catId !=0 && divsionId == 0)
            {
                // Assuming "categoryname" is the Category name, and you're finding the category first
                //var category = await _db.Category // correct table for categories
                //    .FirstOrDefaultAsync(c => c.Category == categoryname && (c.SysID == catId || catId == 0));

                //if (category == null)
                //    return new List<CategoryDropdownViewModel>();

                //var divisions = await _db.Division // now getting divisions that belong to that category
                //    .Where(div => div.SysID == category.SysID && (div.SysID == divsionId || divsionId == 0))
                //    .Select(d => new CategoryDropdownViewModel
                //    {
                //        ID = d.SysID,
                //        Name = d.Division
                //    })
                //    .ToListAsync();

                int categorySysId = catId;

                // Try to get the category if the name is available
                //if (!string.IsNullOrEmpty(categoryname))
                //{
                //    var category = await _db.Category
                //        .FirstOrDefaultAsync(c => c.Category == categoryname && (c.SysID == catId || catId == 0));

                //    if (category != null)
                //    {
                //        categorySysId = category.SysID;
                //    }
                //}

                // Optional: Resolve categoryname if provided
                if (!string.IsNullOrWhiteSpace(categoryname))
                {
                    var category = await _db.Category
                        .FirstOrDefaultAsync(c => c.Category == categoryname && c.SysID == catId);

                    if (category != null)
                    {
                        categorySysId = category.SysID;
                    }
                }


                // Fetch divisions based on resolved categorySysId
                var divisions = await _db.Division
                    .Where(div => div.CategoryID == categorySysId && (div.SysID == divsionId || divsionId == 0)) // Make sure `CategoryID` is correct here
                    .Select(d => new CategoryDropdownViewModel
                    {
                        ID = d.SysID,
                        Name = d.Division
                    })
                    .ToListAsync();

                return divisions;
            }


            // Case 3: Load based on both category and division
            else if (divsionId != 0)                    
            {
                               //var division = await _db.Division
                //    .FirstOrDefaultAsync(div => div.Division == divisionName && div.SysID == category.SysID && (div.SysID == divsionId || divsionId == 0));

                var division = await _db.Division
       .FirstOrDefaultAsync(div =>
           div.Division == divisionName &&      
           (div.SysID == divsionId || divsionId == 0));


                if (division == null)
                    return new List<CategoryDropdownViewModel>();

                var itemGroups = await _db.ItemGroup
                    .Where(i => i.DivisionID == division.SysID)
                    .Select(i => new CategoryDropdownViewModel
                    {
                        ID = i.SysID,
                        Name = i.GroupName
                    })
                    .ToListAsync();

                return itemGroups;
            }


            return new List<CategoryDropdownViewModel>();
        }
    }
}
>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274
