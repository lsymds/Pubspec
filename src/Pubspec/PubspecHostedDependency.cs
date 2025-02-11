using System.Text.Json.Serialization;

namespace LSymds.Pubspec;

/// <summary>
/// Represents a hosted dependency. A hosted dependency is a dependency that is hosted at an alternative, package
/// repository compliant source.
/// <remarks>https://dart.dev/tools/pub/dependencies#hosted-packages</remarks>
/// </summary>
public record PubspecHostedDependency
{
    /// <summary>
    /// Gets the name of the hosted package if it is different to the dependency name in the package specification. 
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    /// <summary>
    /// Gets the URL of the host of the hosted dependency.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}