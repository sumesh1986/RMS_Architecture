﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RMS_Models.Models.API_Models.CommonModels;

namespace RMS_Data.Repository.Interfaces
{
  public interface ICustomerDropdownRepository
    {

        Task<IEnumerable<CustomerDropdownViewModel>> GetAsync(int sysId, string nametitle);
    }
}
