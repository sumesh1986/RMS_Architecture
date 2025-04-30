using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.Users
{
    public class Departments
    {

        [Key] // This is required so EF knows this is the primary key
        public int SysId { get; set; }

  
        [Column("Department")] // Ensure this maps to the correct column
        public required string Department { get; set; } = string.Empty;

        [Required]
        public string Active { get; set; } = "No"; // Stored as "Yes" or "No"
    }
}
