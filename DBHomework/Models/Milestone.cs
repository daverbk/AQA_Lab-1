using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DBHomework.Models;

public record Milestone
{
    [JsonPropertyName("id"), Column("id"), Key] public int Id { get; set; }

    [JsonPropertyName("name"), Column("name")] public string? Name { get; set; }

    [JsonPropertyName("description"), Column("description")] public string? Description { get; set; }

    [JsonPropertyName("start_on"), Column("start_on")] public long? StartOn { get; set; }

    [JsonPropertyName("started_on"), Column("started_on")] public long? StartedOn { get; set; }

    [JsonPropertyName("is_started"), Column("is_started")] public bool? IsStarted { get; set; }

    [JsonPropertyName("due_on"), Column("due_on")] public long? DueOn { get; set; }

    [JsonPropertyName("is_completed"), Column("is_completed")] public bool? IsCompleted { get; set; }

    [JsonPropertyName("completed_on"), Column("completed_on")] public long? CompletedOn { get; set; }

    [JsonPropertyName("project_id"), Column("project_id")] public int? ProjectId { get; set; }
    
    [JsonPropertyName("parent_id"), Column("parent_id")] public int? ParentId { get; set; }

    [JsonPropertyName("refs"), Column("refs")] public string? Refs { get; set; }

    [JsonPropertyName("url"), Column("url")] public string? Url { get; set; } 
    
    [JsonPropertyName("milestones"), ForeignKey("ParentId")] public List<Milestone> SubMilestones { get; set; } = new();
}
