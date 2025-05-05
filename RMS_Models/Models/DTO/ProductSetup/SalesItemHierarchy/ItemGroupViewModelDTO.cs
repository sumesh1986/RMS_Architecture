using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.DTO.ProductSetup.SalesItemHierarchy
{
    public class ItemGroupViewModelDTO
    {
        [Key]
        public int SysID { get; set; }

        public int DivisionID { get; set; }

        [Required]
        public string? GroupName { get; set; }
        [MaxLength(8)]
        public string? Active { get; set; }

        public string? RevenueAC { get; set; }
        public string? DiscountAC { get; set; }
        public string? ExpenseAC { get; set; }
        public string? HideONPDA { get; set; }
        public string? Modifier { get; set; }
        public string? ChoosenModifier { get; set; }
        public string? Tax1 { get; set; }
        public string? Tax2 { get; set; }
        public string? Tax3 { get; set; }
        public string? Tax4 { get; set; }
        public string? Municipality { get; set; }
        public string? ServiceCharge { get; set; }
        public string? LogicalPrinters { get; set; }
    }
}
