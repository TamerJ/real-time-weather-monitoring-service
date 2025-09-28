using System.Xml.Serialization;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Services;

namespace real_time_weather_monitoring_service.Parsers;

public class XmlParser : IDataParser
{
    public WeatherData? Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        try
        {
            var serializer = new XmlSerializer(typeof(WeatherData));
            using var reader = new StringReader(input);
            return serializer.Deserialize(reader) as WeatherData;
        }
        catch
        {
            return null;
        }
    }
}