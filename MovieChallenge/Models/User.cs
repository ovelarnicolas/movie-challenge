using MongoDB.Bson.Serialization.Attributes;
using MovieChallenge.Models;
using System.Text.Json.Serialization;

namespace MovieChallenge.Api.Models
{
    public class User : BaseEntity
    {
        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [BsonElement("password")]
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
    }
}
