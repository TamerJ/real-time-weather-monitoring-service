using real_time_weather_monitoring_service.Subscribers;

namespace real_time_weather_monitoring_service.Publishers;

public interface IPublisher
{
    void Subscribe(ISubscriber subscriber);
    void Unsubscribe(ISubscriber subscriber);
    void Notify();
}