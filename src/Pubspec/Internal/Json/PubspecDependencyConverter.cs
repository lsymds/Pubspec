using System.Text.Json;
using System.Text.Json.Serialization;

namespace LSymds.Pubspec.Internal.Json;

/// <summary>
/// A <see cref="JsonConverter{T}"/> implementation which handles converting complex <see cref="PubspecDependency"/>
/// JSON definitions
/// </summary>
public class PubspecDependencyConverter : JsonConverter<PubspecDependency>
{
    private const string GitDependencyKey = "git";
    private const string HostedDependencyKey = "hosted";
    private const string PathDependencyKey = "path";
    private const string SdkDependencyKey = "sdk";
    private const string VersionDependencyKey = "version";

    public override PubspecDependency? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return new PubspecDependency { Version = reader.GetString() };
        }

        if (reader.TokenType == JsonTokenType.StartObject)
        {
            PubspecDependency? dependency = null;
            string? version = null;

            while (
                reader.Read() && reader.TokenType != JsonTokenType.EndObject && dependency == null
            )
            {
                var dependencyKey = reader.GetString();

                reader.Read();

                if (dependencyKey == GitDependencyKey)
                {
                    dependency = new PubspecDependency
                    {
                        Git = JsonSerializer.Deserialize<PubspecGitDependency>(ref reader, options),
                    };
                }
                else if (dependencyKey == HostedDependencyKey)
                {
                    dependency = new PubspecDependency
                    {
                        Hosted = JsonSerializer.Deserialize<PubspecHostedDependency>(
                            ref reader,
                            options
                        ),
                    };
                }
                else if (dependencyKey == PathDependencyKey)
                {
                    dependency = new PubspecDependency { Path = reader.GetString() };
                }
                else if (dependencyKey == SdkDependencyKey)
                {
                    dependency = new PubspecDependency { Sdk = reader.GetString() };
                }
                else if (dependencyKey == VersionDependencyKey)
                {
                    version = reader.GetString();
                }
            }

            return dependency is not null ? dependency with { Version = version } : null;
        }

        throw new JsonException("Unexpected token type");
    }

    public override void Write(
        Utf8JsonWriter writer,
        PubspecDependency value,
        JsonSerializerOptions options
    )
    {
        throw new NotImplementedException();
    }
}
