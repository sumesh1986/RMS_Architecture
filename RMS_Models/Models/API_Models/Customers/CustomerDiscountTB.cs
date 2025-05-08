using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.Customers
{
    [Table("DiscountTB")]
    public  class CustomerDiscountTB
    {

        [Key]
        public int SysId { get; set; }

        [MaxLength(50)]
        public string DiscountName { get; set; } = string.Empty;

    }
}
