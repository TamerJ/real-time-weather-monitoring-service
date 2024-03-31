﻿using System.Xml.Serialization;
using Newtonsoft.Json;
using real_time_weather_monitoring_service.Enums;
using real_time_weather_monitoring_service.Models;

namespace real_time_weather_monitoring_service.Helpers;

public static class RawDataParserHelper
{
    public static ParserType DetermineParserType(string inputData)
    {
        if (TryParseJson(inputData))
        {
            return ParserType.Json;
        }

        if (TryParseXml(inputData))
        {
            return ParserType.Xml;
        }

        return ParserType.Unknown;
    }

    private static bool TryParseJson(string inputData)
    {
        try
        {
            JsonConvert.DeserializeObject<WeatherBot>(inputData);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool TryParseXml(string inputData)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(WeatherBot));
            using var reader = new StringReader(inputData);
            var obj = (WeatherBot) serializer.Deserialize(reader)!;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}