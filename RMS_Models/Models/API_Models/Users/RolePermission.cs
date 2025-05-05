using RMS_Models.Models.DTO.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.Users
{
   
    public class RolePermission
    {
        [Key]
        public int ParticularID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ModuleName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string DivisionName { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Particulars { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<PositionPermitted> PositionPermissions { get; set; } = new List<PositionPermitted>();

    }



    public class PositionPermitted
    {
        public int Id { get; set; }
        public int PositionID { get; set; }
        public int ParticularID { get; set; }

        public virtual UserPositions UserPosition { get; set; } = null!;
        public virtual RolePermission RolePermission { get; set; } = null!;
    }
}
