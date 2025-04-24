using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.ServiceModels
{
    public class ErrorLog
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string? Message { get; set; }

        [MaxLength(600)]
        public string? StackTrace { get; set; }

        [MaxLength(250)]
        public string? Source { get; set; }
        [MaxLength(250)]
        public string? Path { get; set; }
        [MaxLength(250)]
        public string? Controller { get; set; }
        [MaxLength(250)]
        public string? Action { get; set; }
   
        public int? LineNumber { get; set; }
        [MaxLength(250)]
        public string? FileName { get; set; }

        public DateTime CreatedOn { get; set; }

        [MaxLength(100)]
        public string RegistrationId { get; set; }

        [MaxLength(50)]
        public string User { get; set; }
    }

}
