using real_time_weather_monitoring_service.Enums;

namespace real_time_weather_monitoring_service.FormatDetection;

public interface IFormatDetector
{
    /// <summary>
    /// Determines whether the input matches the format this detector handles.
    /// </summary>
    bool CanHandle(string input);

    /// <summary>
    /// The parser type this detector represents (e.g., Json, Xml, Yaml).
    /// </summary>
    ParserType Type { get; }

}