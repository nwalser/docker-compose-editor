using Sapphire.Data.Yaml;

namespace Sapphire.Data.Internal;

public class DockerStack
{
    public string Name { get; set; } = string.Empty;
    
    public List<Service> Services { get; set; } = [];
    public List<Volume> Volumes { get; set; } = [];
    public List<Network> Networks { get; set; } = [];
    
    
    public static DockerStack FromYaml(YamlDockerStack yamlDockerStack)
    {
        return new DockerStack()
        {
            Services = yamlDockerStack.Services?.Select(Service.FromYaml).ToList() ?? []
        };
    }

    public void Merge(DockerStack stack)
    {
        if (string.IsNullOrWhiteSpace(Name))
            Name = stack.Name;
        
        Services.AddRange(stack.Services);
    }
    
    public YamlDockerStack ToYaml()
    {
        return new YamlDockerStack()
        {
            Name = Name,
            Services = Services.Select(s => s.ToYaml()).ToDictionary()
        };
    }
}