using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Models.Models.API_Models.Users;

namespace RMS_Models.Models.DTO.Users
{
    public class UserPositionsDto
    {

        public int SysId { get; set; }

        [Required(ErrorMessage = "User Position name is required")]
       
        public required string UserPosition { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Active { get; set; } = "Active";
        // Add navigation properties
        public virtual ICollection<PositionPermitted> Permissions { get; set; } = new List<PositionPermitted>();



    }

}
