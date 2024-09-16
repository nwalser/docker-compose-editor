namespace Sapphire.Data.Internal;

public class ServiceEnvironmentVariable
{
    public string Value { get; set; } = string.Empty;
    
    
    public static string ToYaml(ServiceEnvironmentVariable variable)
    {
        return $"{variable.Value}";
    }

    public static ServiceEnvironmentVariable FromYaml(string value)
    {
        return new ServiceEnvironmentVariable()
        {
            Value = value
        };
    }
}