using System.ComponentModel.DataAnnotations;

namespace Admin_Lte.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        [Display(Name = "Role Name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "System ID is required")]
        [Display(Name = "System ID")]
        public int SysId { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = "Active";

        public bool IsActive { get; set; } = true;
    }
}
