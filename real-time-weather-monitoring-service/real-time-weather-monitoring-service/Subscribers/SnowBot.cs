using real_time_weather_monitoring_service.Attributes;
using real_time_weather_monitoring_service.Models;

namespace real_time_weather_monitoring_service.Subscribers;

[BotName("SnowBot")]
public class SnowBot : IWeatherBot
{
    private readonly WeatherBotConfig _config;

    public SnowBot(WeatherBotConfig config)
    {
        _config = config;
    }

    public void Evaluate(WeatherData data)
    {
        if (data.Temperature < _config.TemperatureThreshold)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{_config.Name} activated!");
            Console.WriteLine($"{_config.Message}");
            Console.ResetColor();
        }
    }
}