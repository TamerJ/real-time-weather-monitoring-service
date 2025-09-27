using System.Text;
using real_time_weather_monitoring_service.Factories;
using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Publishers;


namespace real_time_weather_monitoring_service;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("🌤️ Welcome to the Real-Time Weather Monitoring Service!");

        // Load configuration
        var configuration = ConfigurationInitializer.Initialize();
        var appConfig = ConfigurationInitializer.GetConfigValue(configuration);

        var weatherStationPublisher = new WeatherStationPublisher();

        // Display bot status from configuration
        Console.WriteLine("\n🔍 Weather Bot Status:");
        var allBotNames = WeatherBotFactory.GetAvailableBotNames();

        var subscribed = allBotNames
            .Where(name => appConfig.Bots.TryGetValue(name, out var cfg) && cfg.Enabled)
            .ToList();

        var unsubscribed = allBotNames.Except(subscribed);

        foreach (var name in subscribed)
            Console.WriteLine($"✅ {name} → Subscribed");

        foreach (var name in unsubscribed)
            Console.WriteLine($"⚠️ {name} → Not Subscribed");

        // Subscribe active bots
        Console.WriteLine("\n📡 Subscribing active bots...\n");

        foreach (var kvp in appConfig.Bots)
        {
            var botName = kvp.Key;
            var botConfig = kvp.Value;

            botConfig.Name = botName;

            if (!botConfig.Enabled) continue;

            var bot = WeatherBotFactory.Create(botName, botConfig);
            weatherStationPublisher.Subscribe(bot);
        }

        // Input loop
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

            try
            {
                var (detectedType, parser) = ParserFactory.CreateWithType(input!);
                Console.WriteLine($"🔍 Detected format: {detectedType}");

                var weatherData = parser.Parse(input!);

                weatherStationPublisher.State = weatherData;
                weatherStationPublisher.Notify();

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

        Console.WriteLine("👋 Exiting weather monitoring service.");
    }
}