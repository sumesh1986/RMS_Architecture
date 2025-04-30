using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS_Models.Models.API_Models.Users
{
    [Table("UserPositions")] // Make sure this matches your table name
    public class UserPositions
    {
      
       
            [Key] // This is required so EF knows this is the primary key
            public int SysId { get; set; }

            [Required]
            [Column("UserPosition")] // Ensure this maps to the correct column
            public string UserPosition { get; set; } = string.Empty;

            [Required]
            public string Active { get; set; } = "No"; // Stored as "Yes" or "No"

        // Navigation to permissions
        public virtual ICollection<UserPermission>? RolePermissions { get; set; }

    }
    
}
