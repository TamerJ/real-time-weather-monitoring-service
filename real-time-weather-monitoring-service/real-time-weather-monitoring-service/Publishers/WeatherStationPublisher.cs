using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Subscribers;

namespace real_time_weather_monitoring_service.Publishers;

public class WeatherStationPublisher
{
    private readonly List<IWeatherBot> _subscribers = new();
    public WeatherData State { get; set; }

    public void Subscribe(IWeatherBot bot)
    {
        _subscribers.Add(bot);
    }

    public void Notify()
    {
        foreach (var bot in _subscribers)
        {
            bot.Evaluate(State);
        }
    }
}

