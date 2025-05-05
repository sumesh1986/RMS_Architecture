using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.CommonModels;
using System.Text.Json.Serialization;

namespace RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy
{
  
    public class CategoryViewModel 
        //: FlagViewModel
    {
        [Key]
        public int SysID { get; set; }
        [Required]
        public string? Category { get; set; }
        [MaxLength(8)]
        public string? Active { get; set; }
        //public int RefID { get; set; }

    }

}
