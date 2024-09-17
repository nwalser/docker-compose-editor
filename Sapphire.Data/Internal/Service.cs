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
    
    public List<ServiceEnvironmentVariable> EnvironmentVariables { get; set; } = [];
    public List<ServiceVolume> Volumes { get; set; } = [];
    public List<ServicePort> Ports { get; set; } = [];
    public List<ServiceLabel> Labels { get; set; } = [];
    public List<ServiceAnnotation> Annotations { get; set; } = [];
    public List<ServiceNetwork> Networks { get; set; } = [];


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
            EnvironmentVariables = value.Environment.Select(ServiceEnvironmentVariable.FromYaml).ToList(),
            Annotations = value.Annotations.Select(ServiceAnnotation.FromYaml).ToList(),
            Labels = value.Labels.Select(ServiceLabel.FromYaml).ToList(),
            Ports = value.Ports.Select(ServicePort.FromYaml).ToList(),
            Networks = value.Ports.Select(ServiceNetwork.FromYaml).ToList(),
            Volumes = value.Volumes.Select(ServiceVolume.FromYaml).ToList(),
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
            Environment = EnvironmentVariables.Select(ServiceEnvironmentVariable.ToYaml).ToList(),
            Annotations = Annotations.Select(ServiceAnnotation.ToYaml).ToList(),
            Labels = Labels.Select(ServiceLabel.ToYaml).ToList(),
            Ports = Ports.Select(ServicePort.ToYaml).ToList(),
            Networks = Networks.Select(ServiceNetwork.ToYaml).ToList(),
            Volumes = Volumes.Select(ServiceVolume.ToYaml).ToList(),
        };

        return new KeyValuePair<string, YamlService>(Id, service);
    }
    
    public IEnumerable<Issue> Issues()
    {
        if (string.IsNullOrWhiteSpace(Id))
            yield return new Issue(IssueType.Service, "Id must not be empty");
        
        if (string.IsNullOrWhiteSpace(Image))
            yield return new Issue(IssueType.Service, "Image must not be empty");
    }
}