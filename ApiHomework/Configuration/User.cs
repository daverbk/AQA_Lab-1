using ApiHomework.Configuration.Enums;

namespace ApiHomework.Configuration;

public record User
{
    public UserType UserType { get; set; }
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
