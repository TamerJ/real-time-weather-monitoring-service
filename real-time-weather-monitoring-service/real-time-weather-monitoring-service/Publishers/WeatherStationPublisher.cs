using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Subscribers;

namespace real_time_weather_monitoring_service.Publishers;

public class WeatherStationPublisher : IPublisher
{
    private readonly List<ISubscriber> _subscribers;
    public WeatherData State { get; set; }

    public WeatherStationPublisher(List<ISubscriber> subscribers)
    {
        _subscribers = subscribers;
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void Notify()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(this);
        }
    }
}