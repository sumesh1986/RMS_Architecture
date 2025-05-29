using System;

namespace RMS_Models.Models.ServiceModels
{
    public class UserMetadata
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string CountryName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }
        public string Platform { get; set; }
        public string Language { get; set; }
        public string Browser { get; set; }
        public string VisitorId { get; set; }
        public string ScreenResolution { get; set; }
        public bool LocalStorage { get; set; }
        public bool SessionStorage { get; set; }
        public bool Cookie { get; set; }
        public string DeviceType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
