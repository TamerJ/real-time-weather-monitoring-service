using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Publishers;
using real_time_weather_monitoring_service.Services;

namespace real_time_weather_monitoring_service;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the weather monitoring service.");

        var configuration = ConfigurationInitializer.Initialize();
        var appConfig = ConfigurationInitializer.GetConfigValue(configuration);

        var weatherBotMonitors = WeatherBotHelper.InitializeWeatherBotMonitors(appConfig);
        if (weatherBotMonitors.Count == 0)
        {
            Console.WriteLine("No weather bot monitors found.");
            return;
        }

        WeatherStationPublisher weatherStationPublisher = new(weatherBotMonitors);
        var weatherBotParserService = new DataParserService();

        while (true)
        {
            Console.WriteLine("Enter weather data (or 'Q' to quit):");
            var weatherRawDataInput = Console.ReadLine();

            if (string.Equals(weatherRawDataInput, "Q", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            var latestWeatherDataInput = weatherBotParserService.Parse(weatherRawDataInput!);
            weatherStationPublisher.State = latestWeatherDataInput;
            weatherStationPublisher.Notify();
        }

        Console.WriteLine("Exiting weather monitoring service.");
    }
}