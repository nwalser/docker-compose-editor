using Sapphire.Data.Validation;
using Sapphire.Data.Yaml;

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
    
    public List<EnvironmentVariable> EnvironmentVariables { get; set; } = [];
    public List<string> Volumes { get; set; } = [];
    public List<string> Ports { get; set; } = [];
    public List<string> Labels { get; set; } = [];
    public List<string> Annotations { get; set; } = [];
    public List<string> Networks { get; set; } = [];


    public string GetDisplayName()
    {
        return string.IsNullOrEmpty(ContainerName) ? Id : ContainerName;
    }
    
    public static Service FromYaml(KeyValuePair<string, YamlService> entry)
    {
        var value = entry.Value;
        
        return new Service()
        {
            Key = Guid.NewGuid(),
            Id = entry.Key,
            ContainerName = value.ContainerName,
            Image = value.Image,
            Hostname = value.Hostname,
            Command = value.Command,
            EnvFile = value.EnvFile,
            EnvironmentVariables = value.Environment.Select(EnvironmentVariable.FromYaml).ToList(),
            Annotations = value.Annotations,
            Labels = value.Labels,
            Networks = value.Networks,
            Ports = value.Ports,
            Volumes = value.Volumes,
        };
    }

    public KeyValuePair<string, YamlService> ToYaml()
    {
        var service = new YamlService()
        {
            ContainerName = ContainerName,
            Image = Image,
            Hostname = Hostname,
            Command = Command,
            EnvFile = EnvFile,
            Environment = EnvironmentVariables.Select(EnvironmentVariable.ToYaml).ToList(),
            Annotations = Annotations,
            Labels = Labels,
            Networks = Networks,
            Ports = Ports,
            Volumes = Volumes,
        };

        return new KeyValuePair<string, YamlService>(Id, service);
    }
    
    public IEnumerable<Issue> Issues()
    {
        if (string.IsNullOrWhiteSpace(Id))
            yield return new Issue(IssueType.Service, "Id must not be empty");
    }
}