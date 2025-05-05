using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Models.Models.API_Models.CommonModels
{
    public class FlagViewModel
    {
        //public FlagViewModel()
        //{
        //    fldisactive = true;                  // Newly created records are active by default
        //    fldisdeleted = false;                 // Not deleted
        //    fldinserteddatetime = DateTime.Now;   // Set the inserted datetime automatically
        //}

        public bool fldisactive { get; set; }

        [MaxLength(50)]
        public string? fldinsertedby { get; set; }

        public DateTime? fldinserteddatetime { get; set; }

        public int? fldmodifiedno { get; set; }

        [MaxLength(50)]
        public string? fldmodifiedby { get; set; }

        public DateTime? fldmodifieddate { get; set; }

        public bool fldisdeleted { get; set; }

        [MaxLength(50)]
        public string? flddeletedby { get; set; }

        public DateTime? flddeleteddatetime { get; set; }


        public void SetInsert(string insertedBy)
        {
            fldisactive = true;
            fldisdeleted = false;              
            fldinsertedby = insertedBy;
            fldinserteddatetime = DateTime.Now;
        }
     
        public void SetModified(string modifiedBy)
        {
            //fldmodifiedno = (fldmodifiedno ?? 0) + 1;
            fldmodifiedby = modifiedBy;
            fldmodifieddate = DateTime.Now;
        }

        public void SetDeleted(string deletedBy)
        {
            fldisdeleted = true;
            flddeletedby = deletedBy;
            flddeleteddatetime = DateTime.Now;
        }
    }
}


