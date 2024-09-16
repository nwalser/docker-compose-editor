namespace Sapphire.Data.Internal;

public class EnvironmentVariable
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;


    public static string ToYaml(EnvironmentVariable variable)
    {
        return $"{variable.Key}={variable.Value}";
    }

    public static EnvironmentVariable FromYaml(string value)
    {
        var segments = value.Split("=");

        return new EnvironmentVariable()
        {
            Key = segments[0],
            Value = segments[1],
        };
    }
}