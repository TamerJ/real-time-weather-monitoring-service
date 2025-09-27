using System.Text.Json;

namespace real_time_weather_monitoring_service.Parsers;

public class JsonDeserializer<T> : IRawDataDeserializer<T>
{
    public T Deserialize(string raw)
    {
        return JsonSerializer.Deserialize<T>(raw)!;
    }
}