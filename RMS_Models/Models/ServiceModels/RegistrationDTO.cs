using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.ServiceModels
{
    public class RegistrationDTO
    {
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string OwnerName { get; set; }

        [Required]
        [StringLength(100)]
        public string FamilyName { get; set; }

        [Required]
        [StringLength(60)]
        public string Country { get; set; }

        [Required]
        [StringLength(100)]
        public string Place { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(150)]
        public string HeadOffice { get; set; }

        public  string tenantid { get; set; }
    }
}
