using System.Text.Json.Serialization;

namespace ApiHomework.Models;

public record Group
{
    [JsonPropertyName("id")] public int Id { get; set; }
    // DEVNOTE: Populate this record correspondingly to your needs.
}
