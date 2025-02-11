using System.Text.Json.Serialization;

namespace LSymds.Pubspec;

/// <summary>
/// A Git dependency is a dependency that is sourced from a hosted Git repository under an optional ref (i.e. tag
/// or branch name) and an optional path (i.e. path/to/package).
/// <remarks>https://dart.dev/tools/pub/dependencies#git-packages</remarks>
/// </summary>
public record PubspecGitDependency
{
    /// <summary>
    /// Gets the URL that the Git dependency is hosted at.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    /// <summary>
    /// Gets the Git ref that dependency version is contained under.
    /// </summary>
    [JsonPropertyName("ref")]
    public string? Ref { get; init; }

    /// <summary>
    /// Gets the path within the Git repository that the dependency is contained within.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; init; }
}