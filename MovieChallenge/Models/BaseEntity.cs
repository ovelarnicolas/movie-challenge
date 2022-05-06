using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MovieChallenge.Models
{
    public abstract class BaseEntity
    {
        [BsonId(Order = 1)]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string? Id { get; set; } = null;
    }
}
