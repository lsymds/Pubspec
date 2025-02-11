using System.Text.Json.Serialization;

namespace LSymds.Pubspec;

/// <summary>
/// Represents a dependency included within a package specification.
/// </summary>
public record PubspecDependency
{
    /// <summary>
    /// Possible dependency types that are available.
    /// </summary>
    public enum DependencyType
    {
        Git,
        Hosted,
        Path,
        PubDev,
        Sdk
    }
    
    /// <summary>
    /// Gets the git details of the dependency if it is a Git dependency.
    /// <remarks>https://dart.dev/tools/pub/dependencies#git-packages</remarks>
    /// </summary>
    [JsonPropertyName("git")]
    public PubspecGitDependency? Git { get; init; }

    /// <summary>
    /// Gets the hosted details of the dependency if it is hosted on a non-pub.dev repository.
    /// <remarks>https://dart.dev/tools/pub/dependencies#hosted-packages</remarks>
    /// </summary>
    [JsonPropertyName("hosted")]
    public PubspecHostedDependency? Hosted { get; init; }
 
    /// <summary>
    /// Gets the path details of the dependency if it is a local dependency.
    /// <remarks>https://dart.dev/tools/pub/dependencies#path-packages</remarks>
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; init; }
    
    /// <summary>
    /// Gets the SDK of the package if it is sourced from a package.
    /// <remarks>https://dart.dev/tools/pub/dependencies#sdk</remarks>
    /// </summary>
    [JsonPropertyName("sdk")]
    public string? Sdk { get; init; }

    /// <summary>
    /// Gets the type of the dependency.
    /// </summary>
    [JsonIgnore]
    public DependencyType Type
    {
        get
        {
            return this switch
            {
                { Sdk: var s } when !string.IsNullOrWhiteSpace(s) => DependencyType.Sdk,
                { Path: var p } when !string.IsNullOrWhiteSpace(p) => DependencyType.Path,
                { Hosted: not null } => DependencyType.Hosted,
                { Git: not null } => DependencyType.Git,
                _ => DependencyType.PubDev
            };
        }
    }
    
    /// <summary>
    /// Gets the version of the package.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }
}