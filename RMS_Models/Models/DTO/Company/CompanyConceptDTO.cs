using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.DTO.Company
{
    public class CompanyConceptDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? ListofConcept { get; set; }
        [MaxLength(10)]
        public string? Status { get; set; }
    }
}
