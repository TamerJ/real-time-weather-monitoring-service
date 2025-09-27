using real_time_weather_monitoring_service.Enums;

namespace real_time_weather_monitoring_service.FormatDetection;

using System.Text.RegularExpressions;

public class XmlFormatDetector : IFormatDetector
{
    public bool CanHandle(string input) =>
        Regex.IsMatch(input.TrimStart(), @"^<\s*\w+.*?>");

    public ParserType Type => ParserType.Xml;
}
