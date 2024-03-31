using System.Xml.Serialization;

namespace real_time_weather_monitoring_service.Services;

public class XmlDeserializer<T> : IRawDataDeserializer<T>
{
    public T Deserialize(string rawData)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(rawData);

        return (T) serializer.Deserialize(reader)!;
    }
}