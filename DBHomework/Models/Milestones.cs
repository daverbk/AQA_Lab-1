using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBHomework.Models;

public record Milestones
{
    [JsonPropertyName("offset")] public int Offset { get; set; }

    [JsonPropertyName("limit")] public int Limit { get; set; }

    [JsonPropertyName("size")] public int Size { get; set; }

    [JsonPropertyName("_links")] public Links? Links { get; set; }

    [JsonPropertyName("milestones")] public List<Milestone> MilestoneList { get; set; } = new();
}
