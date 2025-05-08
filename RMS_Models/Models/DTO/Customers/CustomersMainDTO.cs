using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.DTO.Customers
{
    public class CustomersMainDTO
    {
        //public int SysID { get; set; }
        public int Title { get; set; }


        [Required]
        [MaxLength(100)] // Optional: Set a length for GroupName if applicable
        public required string CustomerName { get; set; }


    }
}


