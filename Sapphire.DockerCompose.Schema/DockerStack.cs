namespace Sapphire.DockerCompose.Schema;

public class DockerStack
{
    public string Version { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    
    public Dictionary<string, Service> Services { get; set; } = [];
    public Dictionary<string, Volume> Volumes { get; set; } = [];
    public Dictionary<string, Network> Networks { get; set; } = [];
}