using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.ServiceModels
{
    public class Registration
    {
        [Key]
        public int fldSlno { get; set; }

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
        [StringLength(100)]
        public string Place { get; set; }

        [Required]
        [StringLength(60)]
        public string Country { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string HeadOffice { get; set; }



        [StringLength(50)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Plan { get; set; }

        [Required]
        [StringLength(30)]
        public string Ipaddress { get; set; }

        [Required]
        public DateTime fldinserteddatetime { get; set; }

        [Required]
        public bool fldisVerifiedMail { get; set; } = false;

        public DateTime fldMailVerifieddatetime { get; set; }

        [Required]
        [MaxLength(200)]
        public string token { get; set; }

        [Required]
        [MaxLength(3)]
        public int TokenExpiryMinutes { get; set; }

        [Required]
        [MaxLength(20)]
        public string Subscription { get; set; }

        [Required]
        [MaxLength(550)]
        public string SerialNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string License { get; set; }

        [Required]
        public DateTime RegisteredON { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [MaxLength(5)]
        public int Number_of_Days { get; set; }

    }

}
