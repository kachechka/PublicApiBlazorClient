using System.Text.Json.Serialization;

namespace Web.Models
{
    public class Album
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        public Album()
        {
            Title = string.Empty;
        }
    }
}