namespace real_time_weather_monitoring_service.Models;
public class BotConfig
{
    public bool Enabled { get; set; }
    public int HumidityThreshold { get; set; }
    public int TemperatureThreshold { get; set; }
    public string Message { get; set; }
}