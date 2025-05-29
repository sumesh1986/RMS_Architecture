using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RMS_Models.Models.ServiceModels
{
    public class UserMetadataDto
    {
        public string Ip { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }
        public string Platform { get; set; }
        public string UserAgent { get; set; }
        public string Language { get; set; }
        public string Browser { get; set; }
        public string VisitorId { get; set; }
        public string Vendor { get; set; }
        public string Renderer { get; set; }
        public string ScreenResolution { get; set; }
        public bool LocalStorage { get; set; }
        public bool SessionStorage { get; set; }
        public bool Cookie { get; set; }
        public string DeviceType { get; set; } // <-- Include in DTO
    }


}
