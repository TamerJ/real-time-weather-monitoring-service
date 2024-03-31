using real_time_weather_monitoring_service.Enums;
using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Models;

namespace real_time_weather_monitoring_service.Services;

public class DataParserService : IDataParserService
{
    public WeatherBot Parse(string inputData)
    {
        if (string.IsNullOrWhiteSpace(inputData))
        {
            throw new ArgumentException("Input data is null or empty.");
        }

        var parserType = RawDataParserHelper.DetermineParserType(inputData);

        switch (parserType)
        {
            case ParserType.Json:
                var jsonDeserializer = new JsonDeserializer<WeatherBot>();
                return jsonDeserializer.Deserialize(inputData) ?? throw new InvalidOperationException();
            case ParserType.Xml:
                var xmlDeserializer = new XmlDeserializer<WeatherBot>();
                return xmlDeserializer.Deserialize(inputData) ?? throw new InvalidOperationException();
            case ParserType.Unknown:
                throw new ArgumentException("Unknown input format. Please enter valid JSON or XML data.");
            default:
                throw new ArgumentException("Invalid input format. Please enter valid JSON or XML data.");
        }
    }
}