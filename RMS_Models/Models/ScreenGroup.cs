using System.ComponentModel.DataAnnotations;

namespace RMS_Models.Models
{  

    public class ScreenGroup
    {
        public int Id { get; set; }


        [Display(Name = "Screen")]
        public required string ScreenName { get; set; }


        [Display(Name = "Screen Group Name")]
        public required string GroupName { get; set; }

        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
    }

    public class ScreenGroupViewModel
    {
        public required ScreenGroup ScreenGroup { get; set; }
        public required  List<ScreenGroup> ScreenGroupList { get; set; }
        public required List<string> AvailableScreens { get; set; }  // Ensure this exists
    }

}
