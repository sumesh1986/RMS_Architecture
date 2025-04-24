using System.ComponentModel.DataAnnotations;

namespace Admin_Lte.Models
{
    public class UserSetup
    {
        [Required]
        public string Branch { get; set; } = "Default";


        public required string UserCode { get; set; }

        public required string UserName { get; set; }


        public required string Password { get; set; }


        public required string PositionRole { get; set; }

        public required string SwipingCard { get; set; }


        public required string Language { get; set; } = "English";

        public bool Commission { get; set; }
        public required string DefaultMap { get; set; }
        public bool PunchInOut { get; set; }
        public bool DeliveryDriver { get; set; }
        public bool TrainingMode { get; set; }
        public bool IsActive { get; set; }

        // Details section

        public required string LastName { get; set; }
        public required string MobileNo { get; set; }


        [EmailAddress]
        public required string Email { get; set; }

        public decimal Wage { get; set; }
        public decimal OverTime { get; set; }
        public string Department { get; set; }
        public decimal TargetAmount { get; set; }
    }
}
