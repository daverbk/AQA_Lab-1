using System.Text.Json.Serialization;

namespace ApiHomework.Models;

public record Milestone
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string? Name { get; set; }

    [JsonPropertyName("description")] public string? Description { get; set; }

    [JsonPropertyName("start_on")] public long? StartOn { get; set; }

    [JsonPropertyName("started_on")] public long? StartedOn { get; set; }

    [JsonPropertyName("is_started")] public bool IsStarted { get; set; }

    [JsonPropertyName("due_on")] public long? DueOn { get; set; }

    [JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }

    [JsonPropertyName("completed_on")] public string? CompletedOn { get; set; }

    [JsonPropertyName("project_id")] public int ProjectId { get; set; }

    [JsonPropertyName("parent_id")] public int? ParentId { get; set; }

    [JsonPropertyName("refs")] public string? Refs { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("milestones")] public Milestone[] Milestones { get; set; }
}
