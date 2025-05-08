using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.Customers
{
    [Table("PriceGroupMaster")]
    public  class CustomerPrice
    {
        [Key]
        public int SysID { get; set; }
       


        [Column("PriceGroup")]
        public int PriceGroup { get; set; }

    }
}
