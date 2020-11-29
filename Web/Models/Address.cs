using System.Text.Json.Serialization;

namespace Web.Models
{
    public class Address
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }
       
        [JsonPropertyName("suite")]
        public string Suite { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }
        
        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }
        
        [JsonPropertyName("geo")]
        public GeoLocation Location { get; set; }

        public Address()
        {
            Street = string.Empty;
            Suite = string.Empty;
            City = string.Empty;
            ZipCode = string.Empty;
            Location = new GeoLocation();
        }
    }
}