namespace RMS_Models.Models
{
    public class Screenmenu
    {
        public int ID { get; set; }
        public required string Concept { get; set; }
        public required string MenuName { get; set; }
        public bool IsActive { get; set; }
    }
}
