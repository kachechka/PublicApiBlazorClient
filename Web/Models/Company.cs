using System.Text.Json.Serialization;

namespace Web.Models
{
    public class Company
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; set; }
        
        [JsonPropertyName("bs")]
        public string Bs { get; set; }

        public Company()
        {
            Name = string.Empty;
            CatchPhrase = string.Empty;
            Bs = string.Empty;
        }
    }
}