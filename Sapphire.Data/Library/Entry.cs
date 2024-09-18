using Sapphire.Data.Internal;

namespace Sapphire.Data.Library;

public class Entry
{
    public string Title { get; set; }
    public string IconUrl { get; set; }
    public string Description { get; set; }
    public DockerStack Stack { get; set; }
}