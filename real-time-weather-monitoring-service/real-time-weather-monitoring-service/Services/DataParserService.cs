using System.Xml.Serialization;
using Newtonsoft.Json;
using real_time_weather_monitoring_service.Models;
using JsonException = System.Text.Json.JsonException;

namespace real_time_weather_monitoring_service.Services;

public class DataParserService : IDataParserService
{
    public WeatherBot Parse(string inputData)
    {
        if (string.IsNullOrWhiteSpace(inputData))
        {
            throw new ArgumentException("Input data is null or empty.");
        }

        WeatherBot parsedData = default;
        parsedData = TryParseJson(inputData) ?? TryParseXml(inputData);

        if (parsedData == null)
        {
            throw new ArgumentException("Invalid input format. Please enter valid JSON or XML data.");
        }

        return parsedData;
    }

    private WeatherBot TryParseJson(string inputData)
    {
        try
        {
            return JsonConvert.DeserializeObject<WeatherBot>(inputData);
        }
        catch (JsonException)
        {
            // Ignore JSON parsing errors and return null
        }

        return default;
    }

    private WeatherBot TryParseXml(string inputData)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(WeatherBot));
            using var reader = new StringReader(inputData);
            return (WeatherBot) serializer.Deserialize(reader);
        }
        catch (InvalidOperationException)
        {
            // Ignore XML parsing errors and return null
        }

        return default;
    }
}