using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Publishers;

namespace real_time_weather_monitoring_service.Subscribers;

public class RainBotMonitor : ISubscriber
{
    private readonly WeatherBot _rainBot;

    public RainBotMonitor(WeatherBot rainBot)
    {
        _rainBot = rainBot;
        _rainBot.Name = "RainBot";
    }

    public void Update(IPublisher subject)
    {
        var weatherStationPublisher = (WeatherStationPublisher) subject;
        var weatherStation = weatherStationPublisher.State;

        if (weatherStation.Humidity > _rainBot.HumidityThreshold)
        {
            WeatherBotHelper.ActivateWeatherBot(_rainBot);
        }
    }
}