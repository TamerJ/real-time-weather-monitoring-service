using Microsoft.Extensions.Configuration;
using real_time_weather_monitoring_service.Models;

namespace real_time_weather_monitoring_service;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Started the application.");

        var configuration = ConfigurationInitializer.Initialize();

        var appConfig = configuration.Get<AppConfig>();

        Console.WriteLine($"RainBot Enabled: {appConfig?.RainBot?.Enabled}");
        Console.WriteLine($"RainBot Humidity Threshold: {appConfig?.RainBot?.HumidityThreshold}");
        Console.WriteLine($"RainBot Message: {appConfig?.RainBot?.Message}");

        Console.WriteLine($"SunBot Enabled: {appConfig?.SunBot?.Enabled}");
        Console.WriteLine($"SunBot Temperature Threshold: {appConfig?.SunBot?.TemperatureThreshold}");
        Console.WriteLine($"SunBot Message: {appConfig?.SunBot?.Message}");

        Console.WriteLine($"SnowBot Enabled: {appConfig?.SnowBot?.Enabled}");
        Console.WriteLine($"SnowBot Temperature Threshold: {appConfig?.SnowBot?.TemperatureThreshold}");
        Console.WriteLine($"SnowBot Message: {appConfig?.SnowBot?.Message}");
    }
}

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