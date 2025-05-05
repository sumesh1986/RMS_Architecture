using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy
{
    public class CategoryViewModelDTO
    {

        [Key]
        public int SysID { get; set; }
        [Required]
        public string? Category { get; set; }
        [MaxLength(8)]
        public string? Active { get; set; }


    }
}
