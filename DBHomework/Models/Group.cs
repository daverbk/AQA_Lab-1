using System.Text.Json.Serialization;

namespace DBHomework.Models;

public record Group
{
    [JsonPropertyName("id")] public int Id { get; set; }
    
    // DEVNOTE: Populate this record correspondingly to your needs.
}
