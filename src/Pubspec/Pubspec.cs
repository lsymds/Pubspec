using System.Text.Json.Serialization;

namespace LSymds.Pubspec;

/// <summary>
/// A strongly typed version of the pubspec.yaml file included in all package uploads.
/// </summary>
public record Pubspec
{
    /// <summary>
    /// Gets the name of the package.
    /// <remarks>https://dart.dev/tools/pub/pubspec#name</remarks>
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets the version of the package.
    /// <remarks>https://dart.dev/tools/pub/pubspec#version</remarks>
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; init; }
    
    /// <summary>
    /// Gets the description of the package.
    /// <remarks>https://dart.dev/tools/pub/pubspec#homepage</remarks>
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Gets the URL of the home page of the package.
    /// <remarks>https://dart.dev/tools/pub/pubspec#homepage</remarks>
    /// </summary>
    [JsonPropertyName("homepage")]
    public string? Homepage { get; init; }
    
    /// <summary>
    /// Gets the URL of the source code repository of the package.
    /// <remarks>https://dart.dev/tools/pub/pubspec#repository</remarks>
    /// </summary>
    [JsonPropertyName("repository")]
    public string? Repository { get; init; }
    
    /// <summary>
    /// Gets the URL of the issue tracker of the package.
    /// <remarks>https://dart.dev/tools/pub/pubspec#issue-tracker</remarks>
    /// </summary>
    [JsonPropertyName("issue_tracker")]
    public string? IssueTracker { get; init; }
    
    /// <summary>
    /// Gets the URL of the documentation of the package.
    /// <remarks>https://dart.dev/tools/pub/pubspec#documentation</remarks>
    /// </summary>
    [JsonPropertyName("documentation")]
    public string? Documentation { get; init; }

    /// <summary>
    /// Gets the required production dependencies in order for the package to function.
    /// <remarks>https://dart.dev/tools/pub/pubspec#sdk-constraints</remarks>
    /// </summary>
    [JsonPropertyName("dependencies")]
    public Dictionary<string, PubspecHostedDependency>? Dependencies { get; init; }

    /// <summary>
    /// Gets the development dependencies required in order to build and develop this package from source.
    /// <remarks>https://dart.dev/tools/pub/pubspec#sdk-constraints</remarks>
    /// </summary>
    [JsonPropertyName("dev_dependencies")]
    public Dictionary<string, PubspecHostedDependency>? DevelopmentDependencies { get; init; }

    /// <summary>
    /// Gets the dependency overrides used during the development process.
    /// <remarks>https://dart.dev/tools/pub/pubspec#sdk-constraints</remarks>
    /// </summary>
    [JsonPropertyName("dependency_overrides")]
    public Dictionary<string, PubspecHostedDependency>? DependencyOverrides { get; init; }

    /// <summary>
    /// Gets the environmental constraints that the package requires.
    /// <remarks>https://dart.dev/tools/pub/pubspec#sdk-constraints</remarks>
    /// </summary>
    [JsonPropertyName("environment")]
    public Dictionary<string, string>? Environment { get; init; }
    
    /// <summary>
    /// Gets the executables that this package provides.
    /// <remarks>https://dart.dev/tools/pub/pubspec#executables</remarks>
    /// </summary>
    [JsonPropertyName("executables")]
    public Dictionary<string, string>? Executables { get; init; }
    
    /// <summary>
    /// Gets the overrides of platforms that this package supports. By default, most hosted repositories will
    /// try to automatically infer this.
    /// <remarks>https://dart.dev/tools/pub/pubspec#platforms</remarks>
    /// </summary>
    [JsonPropertyName("platforms")]
    public Dictionary<string, PubspecPlatform>? Platforms { get; init; }
    
    /// <summary>
    /// Gets the custom package repository that the package will be published to.
    /// <remarks>https://dart.dev/tools/pub/pubspec#publish_to</remarks>
    /// </summary>
    [JsonPropertyName("publish_to")]
    public string? PublishTo { get; init; }
    
    /// <summary>
    /// Gets a collection of URLs that provide information on how users can help fund the development of the package.
    /// <remarks>https://dart.dev/tools/pub/pubspec#funding</remarks> 
    /// </summary>
    [JsonPropertyName("funding")]
    public IReadOnlyCollection<string> Funding { get; init; }

    /// <summary>
    /// Gets any other fields defined within the package specification. This will contain any other fields in a
    /// package specification that aren't reserved.
    /// <remarks>https://dart.dev/tools/pub/pubspec#supported-fields</remarks>
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, object> Other { get; set; }
}