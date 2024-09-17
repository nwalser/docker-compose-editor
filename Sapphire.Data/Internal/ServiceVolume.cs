namespace Sapphire.Data.Internal;

public class ServiceVolume
{
    public string Value { get; set; } = string.Empty;
    
    public static string ToYaml(ServiceVolume variable)
    {
        return $"{variable.Value}";
    }

    public static ServiceVolume FromYaml(string value)
    {
        return new ServiceVolume()
        {
            Value = value
        };
    }
}