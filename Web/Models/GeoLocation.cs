using System.Text.Json.Serialization;

namespace Web.Models
{
    public class GeoLocation
    {
        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("lng")]
        public string Longitude { get; set; }

        public GeoLocation()
        {
            Latitude = string.Empty;
            Longitude = string.Empty;
        }
    }
}