using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.DTO.Users
{
    public class DepartmentsDTO
    {
        public int SysId { get; set; }

        [Required(ErrorMessage = "Department name is required")]

        public required string Department { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Active { get; set; } = "Active";
    }
}
