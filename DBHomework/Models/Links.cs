using System.Text.Json.Serialization;

namespace DBHomework.Models;

public record Links
{
    [JsonPropertyName("next")] public string? Next { get; set; }

    [JsonPropertyName("prev")] public string? Prev { get; set; }
}
