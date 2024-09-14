namespace Sapphire.DockerCompose.Schema;

public class Service
{
    public string ContainerName { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Command { get; set; } = string.Empty;
    public string EnvFile { get; set; } = string.Empty;
    public string Hostname { get; set; } = string.Empty;
    
    public List<string> Environment { get; set; } = [];
    public List<string> Volumes { get; set; } = [];
    public List<string> Ports { get; set; } = [];
    public List<string> Labels { get; set; } = [];
    public List<string> Annotations { get; set; } = [];
    public List<string> Networks { get; set; } = [];
}