using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.DTO.Customers
{
    public class CustomerGroupDTO
    {
        public int SysId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        //public bool Active { get; set; } = false;

        public string Active { get; set; } = string.Empty;

    }
}
