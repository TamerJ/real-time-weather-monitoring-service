using Newtonsoft.Json;

namespace real_time_weather_monitoring_service.Services;

public class JsonDeserializer<T> : IRawDataDeserializer<T>
{
    public T Deserialize(string rawData)
    {
        return JsonConvert.DeserializeObject<T>(rawData) ?? throw new InvalidOperationException();
    }
}