namespace Sapphire.Data.Internal;

public class ServiceAnnotation
{
    public string Value { get; set; } = string.Empty;
    
    public static string ToYaml(ServiceAnnotation variable)
    {
        return $"{variable.Value}";
    }

    public static ServiceAnnotation FromYaml(string value)
    {
        return new ServiceAnnotation()
        {
            Value = value
        };
    }
}