using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.Customers
{
    public class CustomerTitle
    {

        [Key]
        public int SysId { get; set; }

        [MaxLength(50)]
        public string NameTitle { get; set; } = string.Empty;
      
        //public DateTime InsertedTime { get; set; }
        //public DateTime? LastUpdatedTime { get; set; }

    }
}
