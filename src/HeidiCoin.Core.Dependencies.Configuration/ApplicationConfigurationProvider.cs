namespace HeidiCoin.Core.Dependencies.Configuration;

using System.Reflection;
using Microsoft.Extensions.Configuration;

public static class ApplicationConfigurationProvider
{
    public static IConfiguration GetGlobalConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json"),
                optional: false)
            .Build();

        return configuration;
    }
}