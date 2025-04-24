using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Owner ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Owner ID must be greater than 0")]
        [Display(Name = "Owner ID")]
        public int Owner { get; set; }

        [Required(ErrorMessage = "System ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "System ID must be greater than 0")]
        [Display(Name = "System ID")]
        public int SysId { get; set; }

        public string Status { get; set; }
    }
}

