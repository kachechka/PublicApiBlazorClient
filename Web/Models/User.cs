using System.Text.Json.Serialization;

namespace Web.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("address")]
        public Address Address { get; set; }
        
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        
        [JsonPropertyName("website")]
        public string WebSite { get; set; }
        
        [JsonPropertyName("company")]
        public Company Company { get; set; }

        public User()
        {
            Name = string.Empty;
            UserName = string.Empty;
            Email = string.Empty;
            Address = new Address();
            Phone = string.Empty;
            WebSite = string.Empty;
            Company = new Company();
        }
    }
}