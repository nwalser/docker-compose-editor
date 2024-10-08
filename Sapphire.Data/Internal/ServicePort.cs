﻿namespace Sapphire.Data.Internal;

public class ServicePort
{
    public string Value { get; set; } = string.Empty;
    
    public static string ToYaml(ServicePort variable)
    {
        return $"{variable.Value}";
    }

    public static ServicePort FromYaml(string value)
    {
        return new ServicePort()
        {
            Value = value
        };
    }
}