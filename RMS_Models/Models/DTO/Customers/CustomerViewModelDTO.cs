using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.DTO.Customers
{
    public class CustomerViewModelDTO
    {
        [Key]
        public int SysID { get; set; }
        [Required]
        public string? Nametitle { get; set; }

        //public byte[] ImageData { get; set; }


       

    }
}
