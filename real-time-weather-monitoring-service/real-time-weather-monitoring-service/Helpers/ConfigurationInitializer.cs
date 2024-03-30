using Microsoft.Extensions.Configuration;

namespace real_time_weather_monitoring_service.Helpers;

public static class ConfigurationInitializer
{
    public static IConfigurationRoot Initialize()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
    }
}