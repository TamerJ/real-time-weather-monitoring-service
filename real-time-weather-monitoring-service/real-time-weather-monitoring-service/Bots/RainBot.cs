using real_time_weather_monitoring_service.Attributes;
using real_time_weather_monitoring_service.Models;

namespace real_time_weather_monitoring_service.Subscribers;

[BotName("RainBot")]
public class RainBot : IWeatherBot
{
    private readonly WeatherBotConfig _config;

    public RainBot(WeatherBotConfig config)
    {
        _config = config;
    }

    public void Evaluate(WeatherData data)
    {
        if (_config.Enabled && data.Humidity > _config.HumidityThreshold)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{_config.Name} activated!");
            Console.WriteLine($"{_config.Message}");
            Console.ResetColor();
        }
    }
}