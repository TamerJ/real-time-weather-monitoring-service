using System.Xml.Serialization;

namespace real_time_weather_monitoring_service.Parsers;

public class XmlDeserializer<T> : IRawDataDeserializer<T>
{
    public T Deserialize(string raw)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(raw);
        return (T)serializer.Deserialize(reader)!;
    }
}