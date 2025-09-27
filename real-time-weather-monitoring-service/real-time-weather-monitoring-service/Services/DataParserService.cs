using real_time_weather_monitoring_service.Enums;
using real_time_weather_monitoring_service.Factories;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Parsers;

namespace real_time_weather_monitoring_service.Services;

public class DataParserService : IDataParserService
{
    public WeatherData Parse(string raw, ParserType type)
    {
        var parser = ParserFactory.Create(type);
        return parser.Parse(raw);
    }
}