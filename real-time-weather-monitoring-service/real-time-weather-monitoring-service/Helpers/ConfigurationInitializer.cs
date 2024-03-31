using System.Data;
using Microsoft.Extensions.Configuration;
using real_time_weather_monitoring_service.Models;

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

    public static AppConfig GetConfigValue(IConfigurationRoot configuration)
    {
        var appConfig = configuration.Get<AppConfig>();
        if (appConfig != null) return appConfig;

        Console.WriteLine("AppConfig is empty.");
        throw new ConstraintException("AppConfig is empty.");
    }
}