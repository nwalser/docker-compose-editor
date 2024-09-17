namespace Sapphire.Data.Internal;

public class ServiceLabel
{
    public string Value { get; set; } = string.Empty;
    
    
    public static string ToYaml(ServiceLabel variable)
    {
        return $"{variable.Value}";
    }

    public static ServiceLabel FromYaml(string value)
    {
        return new ServiceLabel()
        {
            Value = value
        };
    }
}