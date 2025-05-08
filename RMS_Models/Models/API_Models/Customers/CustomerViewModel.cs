using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.Customers
{

    [Table("CustomerTitles")]
    public class CustomerViewModel
    {
        [Key]
        public int SysID { get; set; }
        [Required]
        public string? Nametitle { get; set; } = string.Empty;

        //public byte[] ImageData { get; set; }
    }
}
