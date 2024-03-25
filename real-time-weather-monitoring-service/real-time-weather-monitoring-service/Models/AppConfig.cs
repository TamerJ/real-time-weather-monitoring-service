namespace real_time_weather_monitoring_service.Models;

public class AppConfig
{
    public BotConfig? RainBot { get; set; }
    public BotConfig? SunBot { get; set; }
    public BotConfig? SnowBot { get; set; }
}