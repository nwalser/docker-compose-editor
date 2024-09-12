using System.Reactive.Subjects;
using Sapphire.DockerCompose.Schema;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Sapphire.App.Services;

public class DataService
{
    public BehaviorSubject<DockerStack>? Stack { get; set; }
    public string? Path { get; set; }
    
    
    public void New()
    {
        Stack = new BehaviorSubject<DockerStack>(new DockerStack());
        Path = null;
    }

    public void Open(string path)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        
        var yml = File.ReadAllText(path);
        var stack = deserializer.Deserialize<DockerStack>(yml);

        Stack = new BehaviorSubject<DockerStack>(stack);
        Path = path;
    }

    public void Save()
    {
        if (Path is null)
            return;
        
        var serializer = new SerializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();

        var yml = serializer.Serialize(Stack?.Value);
        File.WriteAllText(Path, yml);
    }

    public void Close()
    {
        Stack = null;
        Path = null;
    }
}