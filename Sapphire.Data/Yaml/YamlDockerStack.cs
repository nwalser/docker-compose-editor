using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Sapphire.Data.Yaml;

public class YamlDockerStack
{
    public string Version { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    
    public Dictionary<string, YamlService>? Services { get; set; }
    public Dictionary<string, YamlVolume>? Volumes { get; set; }
    public Dictionary<string, YamlNetwork>? Networks { get; set; }

    
    
    
    private static readonly ISerializer Serializer = new SerializerBuilder()
        .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitEmptyCollections | DefaultValuesHandling.OmitDefaults)
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build();
    
    private static readonly IDeserializer Deserializer = new DeserializerBuilder()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build();

    public static YamlDockerStack FromYaml(string yaml)
    {
        return Deserializer.Deserialize<YamlDockerStack>(yaml); // todo add better deserialization for different docker representations
    }

    public string ToYaml()
    {
        return Serializer.Serialize(this);
    }
}