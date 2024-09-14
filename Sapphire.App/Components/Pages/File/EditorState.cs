using Sapphire.DockerCompose.Schema;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Sapphire.App.Components.Pages.File;

public class EditorState
{
    private static readonly ISerializer Serializer = new SerializerBuilder()
        .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitEmptyCollections | DefaultValuesHandling.OmitDefaults)
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build();
    
    private static readonly IDeserializer Deserializer = new DeserializerBuilder()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build();
    
    
    public Stack<string> Performed { get; } = new(5);
    public Stack<string> Recalled { get; } = new(5); // todo: implement with dropout stacks
    public DockerStack Stack { get; set; } = new();


    public EditorState()
    {
        PushState();
    }
    

    public void Undo()
    {
        if (Performed.Count < 2)
            return;

        var performed = Performed.Pop();
        Recalled.Push(performed);
        Stack = Deserializer.Deserialize<DockerStack>(Performed.Peek());
    }

    public void Redo()
    {
        if (Recalled.Count == 0)
            return;

        var recalled = Recalled.Pop();
        Performed.Push(recalled);
        Stack = Deserializer.Deserialize<DockerStack>(recalled);
    }

    public void PushState()
    {
        var serialized = Serializer.Serialize(Stack);
        Performed.Push(serialized);
        Recalled.Clear();
    }
    
    public void Import(string yml)
    {
        var stack = Deserializer.Deserialize<DockerStack>(yml);

        if (string.IsNullOrWhiteSpace(stack.Name)) stack.Name = stack.Name;
        
        foreach (var service in stack.Services)
            Stack.Services.Add(service.Key, service.Value);
        
        foreach (var volume in stack.Volumes)
            Stack.Volumes.Add(volume.Key, volume.Value);
        
        foreach (var network in stack.Networks)
            Stack.Networks.Add(network.Key, network.Value);
        
        PushState();
    }
}