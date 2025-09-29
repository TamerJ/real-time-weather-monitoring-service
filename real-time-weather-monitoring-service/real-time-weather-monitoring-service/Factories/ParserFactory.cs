using real_time_weather_monitoring_service.Enums;
using real_time_weather_monitoring_service.Parsers;
using real_time_weather_monitoring_service.FormatDetection;
using real_time_weather_monitoring_service.Services;

namespace real_time_weather_monitoring_service.Factories;

public static class ParserFactory
{
    private static readonly List<IFormatDetector> detectors = new()
    {
        new JsonFormatDetector(),
        new XmlFormatDetector(),
        // new YamlFormatDetector() // Add when ready
    };

    public static (ParserType Type, IDataParser Parser) CreateWithType(string input)
    {
        var type = DetectParserType(input);
        var parser = Create(type);
        return (type, parser);
    }


    public static IDataParser Create(ParserType type) => type switch
    {
        ParserType.Json => new JsonParser(),
        ParserType.Xml => new XmlParser(),
        //ParserType.Yaml => new YamlParser(), // future
        _ => throw new NotSupportedException($"Unsupported parser type: {type}")
    };

    private static ParserType DetectParserType(string input)
    {
        foreach (var detector in detectors)
        {
            if (detector.CanHandle(input))
                return detector.Type;
        }

        return ParserType.Unknown;
    }
}