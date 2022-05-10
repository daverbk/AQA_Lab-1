using System.Text.Json.Serialization;

namespace DBHomework.Models;

public record User
{
    [JsonPropertyName("id")] public int Id { get; set; }
    
    // DEVNOTE: Populate this record correspondingly to your needs.
}
