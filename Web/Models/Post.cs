using System.Text.Json.Serialization;

namespace Web.Models
{
    public class Post
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        public Post()
        {
            Title = string.Empty;
            Body = string.Empty;
        }
    }
}