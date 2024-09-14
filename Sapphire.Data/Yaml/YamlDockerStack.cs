namespace Sapphire.Data.Yaml;

public class YamlDockerStack
{
    public string Version { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    
    public Dictionary<string, YamlService> Services { get; set; } = [];
    public Dictionary<string, YamlVolume> Volumes { get; set; } = [];
    public Dictionary<string, YamlNetwork> Networks { get; set; } = [];
}