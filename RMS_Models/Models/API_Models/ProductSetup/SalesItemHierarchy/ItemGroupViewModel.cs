using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy
{
    public class ItemGroupViewModel
    {
        [Key]
        public int SysID { get; set; }

        public int DivisionID { get; set; }

        [Required]
        [MaxLength(100)] // Optional: Set a length for GroupName if applicable
        public string GroupName { get; set; }

        [MaxLength(3)]
        public string? Active { get; set; }

        [MaxLength(50)]
        public string? RevenueAC { get; set; }

        [MaxLength(50)]
        public string? DiscountAC { get; set; }

        [MaxLength(50)]
        public string? ExpenseAC { get; set; }

        [MaxLength(3)]
        public string? HideONPDA { get; set; }

        [MaxLength(3)]
        public string? Modifier { get; set; }

        public int? ChoosenModifier { get; set; }

        [MaxLength(3)]
        public string? Tax1 { get; set; }

        [MaxLength(3)]
        public string? Tax2 { get; set; }

        [MaxLength(3)]
        public string? Tax3 { get; set; }

        [MaxLength(3)]
        public string? Tax4 { get; set; }

        [MaxLength(3)]
        public string? Municipality { get; set; }

        [MaxLength(3)]
        public string? ServiceCharge { get; set; }

        [MaxLength(350)]
        public string? LogicalPrinters { get; set; }

    }
}
