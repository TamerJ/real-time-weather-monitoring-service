using real_time_weather_monitoring_service.Publishers;

namespace real_time_weather_monitoring_service.Subscribers;

public interface ISubscriber
{
    void Update(IPublisher subject);
}