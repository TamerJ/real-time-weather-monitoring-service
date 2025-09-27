using real_time_weather_monitoring_service.Models;

namespace real_time_weather_monitoring_service.Subscribers;

public interface IWeatherBot
{
    void Evaluate(WeatherData data);
}