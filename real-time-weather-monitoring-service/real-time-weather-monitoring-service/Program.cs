using real_time_weather_monitoring_service.Services;
using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Publishers;
using real_time_weather_monitoring_service.Subscribers;

namespace real_time_weather_monitoring_service;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the weather monitoring service.");

        // Load configuration from appsettings.json
        var configuration = ConfigurationInitializer.Initialize();
        var appConfig = ConfigurationInitializer.GetConfigValue(configuration);

        // Initialize publisher
        var weatherStationPublisher = new WeatherStationPublisher();

        // Dynamically inject bots based on config
        foreach (var kvp in appConfig?.Bots)
        {
            var botName = kvp.Key;
            var botConfig = kvp.Value;

            if (!botConfig.Enabled) continue;

            botConfig.Name = botName;

            IWeatherBot bot = botName.ToLowerInvariant() switch
            {
                "rainbot" => new RainBot(botConfig),
                "sunbot" => new SunBot(botConfig),
                "snowbot" => new SnowBot(botConfig),
                _ => throw new InvalidOperationException($"Unknown bot type: {botName}")
            };

            weatherStationPublisher.Subscribe(bot);
        }

        // Initialize parser
        IDataParserService parserService = new DataParserService();

        // Main input loop
        while (true)
        {
            Console.WriteLine("Enter weather data (or 'Q' to quit):");
            var input = Console.ReadLine();

            if (string.Equals(input, "Q", StringComparison.OrdinalIgnoreCase))
                break;

            try
            {
                var weatherData = parserService.Parse(input!);
                weatherStationPublisher.State = weatherData;
                weatherStationPublisher.Notify();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }

        Console.WriteLine("Exiting weather monitoring service.");
    }
}