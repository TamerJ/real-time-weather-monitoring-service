using real_time_weather_monitoring_service.Enums;
using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Models;

namespace real_time_weather_monitoring_service.Services;

public class DataParserService : IDataParserService
{
    public WeatherData Parse(string inputData)
    {
        if (string.IsNullOrWhiteSpace(inputData))
            throw new ArgumentException("Input data is empty.");

        var parserType = RawDataParserHelper.DetermineParserType(inputData);

        return parserType switch
        {
            ParserType.Json => new JsonDeserializer<WeatherData>().Deserialize(inputData),
            ParserType.Xml => new XmlDeserializer<WeatherData>().Deserialize(inputData),
            _ => throw new ArgumentException("Unknown input format.")
        };
    }
}