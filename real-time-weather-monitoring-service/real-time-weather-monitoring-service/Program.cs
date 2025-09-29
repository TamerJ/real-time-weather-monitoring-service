using System.Text;
using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Factories;
using real_time_weather_monitoring_service.Publishers;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("🌤️ Welcome to the Real-Time Weather Monitoring Service!\n");

        // Load configuration
        var appConfig = LoadConfiguration();

        // Display bot status
        DisplayBotStatus(appConfig);

        // Subscribe active bots
        var publisher = new WeatherStationPublisher();
        SubscribeActiveBots(appConfig, publisher);

        // Start user input loop
        RunInputLoop(publisher);

        Console.WriteLine("👋 Exiting weather monitoring service.");
    }

    private static AppConfig LoadConfiguration()
    {
        var configuration = ConfigurationInitializer.Initialize();
        return ConfigurationInitializer.GetConfigValue(configuration);
    }

    private static void DisplayBotStatus(AppConfig appConfig)
    {
        Console.WriteLine("🔍 Weather Bot Status:");

        var allBotNames = WeatherBotFactory.GetAvailableBotNames();
        var subscribed = allBotNames
            .Where(name => appConfig.Bots.TryGetValue(name, out var cfg) && cfg.Enabled)
            .ToList();
        var unsubscribed = allBotNames.Except(subscribed);

        foreach (var name in subscribed)
            Console.WriteLine($"✅ {name} → Subscribed");

        foreach (var name in unsubscribed)
            Console.WriteLine($"⚠️ {name} → Not Subscribed");

        Console.WriteLine();
    }

    private static void SubscribeActiveBots(AppConfig appConfig, WeatherStationPublisher publisher)
    {
        Console.WriteLine("📡 Subscribing active bots...\n");

        foreach (var (botName, botConfig) in appConfig.Bots)
        {
            botConfig.Name = botName;
            if (!botConfig.Enabled) continue;

            var bot = WeatherBotFactory.Create(botName, botConfig);
            publisher.Subscribe(bot);
        }
    }

    private static void RunInputLoop(WeatherStationPublisher publisher)
    {
        Console.WriteLine("📥 Paste raw weather data (XML or JSON). Type 'Q' to quit.\n");

        while (true)
        {
            Console.Write("Input > ");
            var input = Console.ReadLine()?.Trim();

            if (string.Equals(input, "Q", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\n👋 Shutting down weather monitoring service...");
                break;
            }

            ProcessInput(input, publisher);
        }
    }

    private static void ProcessInput(string? input, WeatherStationPublisher publisher)
    {
        if (string.IsNullOrWhiteSpace(input)) return;

        try
        {
            var (detectedType, parser) = ParserFactory.CreateWithType(input);
            Console.WriteLine($"🔍 Detected format: {detectedType}");

            var weatherData = parser.Parse(input);

            publisher.State = weatherData;
            publisher.Notify();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                $"✅ Published: {weatherData.Location}, {weatherData.Temperature}°C, {weatherData.Humidity}%");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Error: {ex.Message}");
            Console.ResetColor();
        }
    }
}