namespace Sapphire.Data.Internal;

public class ServiceNetwork
{
    public string Value { get; set; } = string.Empty;
    
    public static string ToYaml(ServiceNetwork variable)
    {
        return $"{variable.Value}";
    }

    public static ServiceNetwork FromYaml(string value)
    {
        return new ServiceNetwork()
        {
            Value = value
        };
    }
}