namespace real_time_weather_monitoring_service.Services;

public interface IRawDataDeserializer<out T>
{
    T Deserialize(string rawData);
}