namespace Sapphire.DockerCompose.Schema;

public class Service
{
    public string? Image { get; set; }
    public string? Command { get; set; }
    public List<string>? Environment { get; set; }
    public List<string>? Volumes { get; set; }
    public List<string>? Ports { get; set; }
}