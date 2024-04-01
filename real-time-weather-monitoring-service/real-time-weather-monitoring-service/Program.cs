using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Publishers;
using real_time_weather_monitoring_service.Services;
using real_time_weather_monitoring_service.Subscribers;

namespace real_time_weather_monitoring_service;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to weather monitoring service.");

        var configuration = ConfigurationInitializer.Initialize();
        var appConfig = ConfigurationInitializer.GetConfigValue(configuration);

        var weatherBotMonitors = WeatherBotHelper.InitializeWeatherBotMonitors(appConfig);
        if (weatherBotMonitors.Count == 0)
        {
            Console.WriteLine("No weather bot monitors found.");
            return;
        }

        WeatherStationPublisher weatherStationPublisher = new(weatherBotMonitors);

        Console.WriteLine("Enter weather data:");
        var weatherRawDataInput = Console.ReadLine();

        var weatherBotParserService = new DataParserService();
        var latestWeatherDataInput = weatherBotParserService.Parse(weatherRawDataInput!);
        weatherStationPublisher.State = latestWeatherDataInput;
        weatherStationPublisher.Notify();

        Console.ReadLine();
    }
}