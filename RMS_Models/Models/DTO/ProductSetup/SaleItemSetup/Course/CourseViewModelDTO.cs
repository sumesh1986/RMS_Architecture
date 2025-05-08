using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.SaleItemSetup.Course
{
    public class CourseViewModelDTO
    {
        [Key]
        public int SysID { get; set; }
        [Required]
        public string? CourseType { get; set; }
        [MaxLength(3)]
        public string? Active { get; set; }
    }
}
