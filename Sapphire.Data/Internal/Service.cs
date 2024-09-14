namespace Sapphire.Data.Internal;

public class Service
{
    public Guid Key { get; set; } = Guid.NewGuid();
    public bool Open { get; set; } = false;
    
    public string Id { get; set; } = string.Empty;
    
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