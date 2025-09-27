using System.Text.RegularExpressions;
using real_time_weather_monitoring_service.Enums;

namespace real_time_weather_monitoring_service.FormatDetection;

public class JsonFormatDetector: IFormatDetector
{
    public bool CanHandle(string input) =>
        Regex.IsMatch(input.TrimStart(), @"^\s*[\{\[]");

    public ParserType Type => ParserType.Json;

}