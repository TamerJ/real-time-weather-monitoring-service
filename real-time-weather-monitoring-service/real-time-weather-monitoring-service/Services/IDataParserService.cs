using real_time_weather_monitoring_service.Models;

namespace real_time_weather_monitoring_service.Services;

public interface IDataParserService
{
    WeatherStation Parse(string inputData);
}