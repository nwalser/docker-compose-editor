namespace Sapphire.Data.Internal;

public class DockerStack
{
    public string Name { get; set; } = string.Empty;
    
    public List<Service> Services { get; set; } = [];
    public List<Volume> Volumes { get; set; } = [];
    public List<Network> Networks { get; set; } = [];
}