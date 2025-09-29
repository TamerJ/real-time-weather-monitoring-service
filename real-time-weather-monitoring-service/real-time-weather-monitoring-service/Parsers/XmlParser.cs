using System.Text.RegularExpressions;
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
            string normalizedInput = NormalizeXml(input);

            var serializer = new XmlSerializer(typeof(WeatherData));
            using var reader = new StringReader(normalizedInput);
            return serializer.Deserialize(reader) as WeatherData;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    /// <summary>
    /// Converts all XML tag names to lowercase to allow case-insensitive deserialization.
    /// Values inside the tags are preserved.
    /// </summary>
    private string NormalizeXml(string inputXml)
    {
        return Regex.Replace(inputXml, @"</?[^>]+>", match =>
        {
            string tag = match.Value;
            return Regex.Replace(tag, @"[a-zA-Z]+", t => t.Value.ToLower());
        });
    }
}