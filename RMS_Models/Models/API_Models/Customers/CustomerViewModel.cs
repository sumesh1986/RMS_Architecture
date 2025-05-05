using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.Customers
{
    public class CustomerViewModel
    {
        [Key]
        public int SysID { get; set; }
        [Required]
        public string? Nametitle { get; set; }
    }
}
