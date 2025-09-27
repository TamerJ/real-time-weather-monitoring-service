namespace real_time_weather_monitoring_service.Parsers;

public interface IRawDataDeserializer<out T>
{
    T Deserialize(string raw);
}