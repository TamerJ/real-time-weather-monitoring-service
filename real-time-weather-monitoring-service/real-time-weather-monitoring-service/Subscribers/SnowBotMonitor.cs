using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Publishers;

namespace real_time_weather_monitoring_service.Subscribers;

public class SnowBotMonitor : ISubscriber
{
    private readonly WeatherBot _snowBot;

    public SnowBotMonitor(WeatherBot rainBot)
    {
        _snowBot = rainBot;
        _snowBot.Name = "SnowBot";
    }

    public void Update(IPublisher subject)
    {
        var weatherStationPublisher = (WeatherStationPublisher) subject;
        var weatherStation = weatherStationPublisher.State;

        if (weatherStation.Temperature < _snowBot.TemperatureThreshold)
        {
            WeatherBotHelper.ActivateWeatherBot(_snowBot);
        }
    }
}