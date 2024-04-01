namespace real_time_weather_monitoring_service.Models;

public class AppConfig
{
    public WeatherBot? RainBot { get; set; }
    public WeatherBot? SunBot { get; set; }
    public WeatherBot? SnowBot { get; set; }
}