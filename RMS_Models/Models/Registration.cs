using System.ComponentModel.DataAnnotations;

namespace RMS_Models.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Company Name is required")]
        public required string CompanyName { get; set; }

        [Required(ErrorMessage = "Owner Name is required")]
        public required string OwnerName { get; set; }

        public required string FamilyName { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public required string Country { get; set; }

        [Required(ErrorMessage = "Place is required")]
        public required string Place { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Phone number must be 12 digits")]
        public required string Phone { get; set; }

        public required string ProductId { get; set; }
        public required string RegistrationNumber { get; set; }
        public bool IsHeadOffice { get; set; }
        public DateTime FileCreatedOn { get;  set; }
        public string? FileCreatedAt { get;  set; }

    }
}
