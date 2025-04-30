using RMS_Models.Models.API_Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.DTO.Users
{
    public class UserPermissionDTO
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string ModuleName { get; set; }

        [MaxLength(100)]
        public required string DivisionName { get; set; }

        [MaxLength(200)]
        public required string Particulars { get; set; }

        public bool IsGranted { get; set; }
        public bool IsDenied { get; set; }

        // Foreign key for UserPosition
        public int UserPositionId { get; set; }

        [ForeignKey("UserPositionId")]
        public virtual UserPositions? UserPosition { get; set; }
    }
}
