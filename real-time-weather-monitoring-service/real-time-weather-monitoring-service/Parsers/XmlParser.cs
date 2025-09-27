using System.Xml.Serialization;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Services;

namespace real_time_weather_monitoring_service.Parsers;

public class XmlParser : IDataParser
{
    public WeatherData Parse(string input)
    {
        var serializer = new XmlSerializer(typeof(WeatherData));
        using var reader = new StringReader(input);
        return (WeatherData)serializer.Deserialize(reader)!;
    }
}