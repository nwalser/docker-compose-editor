using Sapphire.Data.Internal;
using Sapphire.Data.Yaml;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Sapphire.Data;

public class Transformations
{
    private static readonly ISerializer Serializer = new SerializerBuilder()
        .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitEmptyCollections | DefaultValuesHandling.OmitDefaults)
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build();
    
    private static readonly IDeserializer Deserializer = new DeserializerBuilder()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build();
    
    
    public YamlDockerStack ToYamlDockerStack(DockerStack dockerStack)
    {
        return new YamlDockerStack();
    }

    public DockerStack ImportFromYamlDockerStack(YamlDockerStack yamlDockerStack, DockerStack dockerStack)
    {
        
        
        return dockerStack;
    }

    public DockerStack ImportFromCommand(string command, DockerStack dockerStack)
    {
        return dockerStack;
    }
}