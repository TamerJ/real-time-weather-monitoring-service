using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Publishers;

namespace real_time_weather_monitoring_service.Subscribers;

public class SunBotMonitor : ISubscriber
{
    private readonly WeatherBot _sunBot;

    public SunBotMonitor(WeatherBot sunBot)
    {
        _sunBot = sunBot;
        _sunBot.Name = "SunBot";
    }

    public void Update(IPublisher subject)
    {
        var weatherStationPublisher = (WeatherStationPublisher) subject;
        var weatherStation = weatherStationPublisher.State;

        if (weatherStation.Temperature > _sunBot.TemperatureThreshold)
        {
            WeatherBotHelper.ActivateWeatherBot(_sunBot);
        }
    }
}