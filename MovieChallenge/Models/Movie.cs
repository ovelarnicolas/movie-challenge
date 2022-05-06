using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MovieChallenge.Models
{
    [BsonIgnoreExtraElements]
    public class Movie : BaseEntity
    {
        [BsonElement("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [BsonElement("plot")]
        public string Plot { get; set; } = string.Empty;

        [BsonElement("genres")]
        [JsonPropertyName("genres")]
        public List<string>? Genres { get; set; } = null;

        [BsonElement("released")]
        [JsonPropertyName("released")]
        public DateTime? Released { get; set; } = null;

        [BsonElement("year")]
        [JsonPropertyName("year")]
        public int? Year { get; set; } = null;
    }
}
