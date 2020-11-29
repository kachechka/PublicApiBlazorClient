using System.Text.Json.Serialization;

namespace Web.Models
{
    public class Todo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userIdid")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("completed")]
        public bool IsCompleted { get; set; }

        public Todo()
        {
            Title = string.Empty;
        }
    }
}