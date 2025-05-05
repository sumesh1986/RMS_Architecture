using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.Customers
{
    public class CustomerGroup
    {
        [Key]
        public int SysId { get; set; }

        [MaxLength(50)]
        public string GroupName { get; set; } = string.Empty;

        public string Active { get; set; } = string.Empty;
        //public bool Active { get; set; } = false;

        //public DateTime InsertedTime { get; set; }
        //public DateTime? LastUpdatedTime { get; set; }
    }
}



