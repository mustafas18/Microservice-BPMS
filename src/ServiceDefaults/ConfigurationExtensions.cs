namespace Microsoft.Extensions.Configuration;

public static class ConfigurationExtensions
{
    public static string GetRequiredValue(this IConfiguration configuration, string name) =>
        configuration[name] ?? throw new System.Exception($"Configuration missing value for: {(configuration is IConfigurationSection s ? s.Path + ":" + name : name)}");
}
