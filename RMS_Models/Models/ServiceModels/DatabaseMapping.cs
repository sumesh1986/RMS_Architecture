using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.ServiceModels
{
    public class DatabaseMapping
    {
        [Key]
        public int Slno { get; set; }

        public string Token { get; set; }

        public string RegNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }

    }
}
