namespace Sapphire.DockerCompose.Schema;

public class DockerStack
{
    public string? Version { get; set; }
    public string? Name { get; set; }
    
    public Dictionary<string, Service>? Services { get; set; }
    public Dictionary<string, Volume>? Volumes { get; set; }

    public DockerStack()
    {
        
    }
}