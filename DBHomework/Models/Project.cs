using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DBHomework.Models;

public record Project
{
    [JsonPropertyName("id"), Column("id")] public int Id { get; set; }

    [JsonPropertyName("name"), Column("name")] public string? Name { get; set; }

    [JsonPropertyName("announcement"), Column("announcement")] public string? Announcement { get; set; }

    [JsonPropertyName("show_announcement"), Column("show_announcement")] public bool ShowAnnouncement { get; set; }

    [JsonPropertyName("is_completed"), Column("is_completed")] public bool? IsCompleted { get; set; }

    [JsonPropertyName("completed_on"), Column("completed_on")] public long? CompletedOn { get; set; }

    [JsonPropertyName("suite_mode"), Column("suite_mode")] public int SuiteMode { get; set; }

    [JsonPropertyName("default_role_id"), Column("default_role_id")] public string? DefaultRoleId { get; set; }

    [JsonPropertyName("url"), Column("url")] public string? Url { get; set; }

    [JsonPropertyName("users")] public List<User> Users { get; set; } = new();

    [JsonPropertyName("groups")] public List<Group> Groups { get; set; } = new();
}

// TODO: Implement additional tables Users and Groups to store the two properties data.
