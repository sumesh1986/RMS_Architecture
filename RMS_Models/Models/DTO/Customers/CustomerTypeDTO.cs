using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.DTO.Customers
{
    public class CustomerTypeDTO
    {
       
        public int SysId { get; set; }
        public string NameType { get; set; } = string.Empty;
        //public bool Active { get; set; } = false;

        public string Active { get; set; } = string.Empty;

    }



}



