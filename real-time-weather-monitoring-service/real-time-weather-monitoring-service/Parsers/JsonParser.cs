using System.Text.Json;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Services;

namespace real_time_weather_monitoring_service.Parsers;

public class JsonParser : IDataParser
{
    public WeatherData? Parse(string input)
    {
        try
        {
            return JsonSerializer.Deserialize<WeatherData>(input, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch
        {
            return null;
        }
    }
}
