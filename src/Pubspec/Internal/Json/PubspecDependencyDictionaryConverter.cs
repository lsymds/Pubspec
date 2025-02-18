using System.Text.Json;
using System.Text.Json.Serialization;

namespace LSymds.Pubspec.Internal.Json;

public class PubspecDependencyDictionaryConverter : JsonConverter<Dictionary<string, PubspecDependency>>
{
    private PubspecDependencyConverter _dependencyConverter = new();

    public override Dictionary<string, PubspecDependency>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dependencies = new Dictionary<string, PubspecDependency>();

        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var dependencyKey = reader.GetString()!;
                reader.Read();
                dependencies.Add(dependencyKey, _dependencyConverter.Read(ref reader, typeof(PubspecDependency), options)!);
            } 
        }

        return dependencies;
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, PubspecDependency> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}