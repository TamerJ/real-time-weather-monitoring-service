using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Subscribers;

namespace real_time_weather_monitoring_service.Helpers;

public static class WeatherBotHelper
{
    public static void ActivateWeatherBot(WeatherBot weatherBot)
    {
        weatherBot.Enabled = true;
        PrintActivationMessage(weatherBot);
    }

    private static void PrintActivationMessage(WeatherBot weatherBot)
    {
        SetConsoleColor(ConsoleColor.Green);
        Console.WriteLine($"{weatherBot.Name} activated!");
        Console.WriteLine(weatherBot.Message);
        ResetConsoleColor();
    }

    private static void SetConsoleColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    private static void ResetConsoleColor()
    {
        Console.ResetColor();
    }

    public static List<ISubscriber> InitializeWeatherBotMonitors(AppConfig appConfig)
    {
        if (appConfig == null)
        {
            throw new ArgumentNullException(nameof(appConfig));
        }

        var subscribers = new List<ISubscriber>();

        if (appConfig.SunBot != null)
        {
            subscribers.Add(new SunBotMonitor(appConfig.SunBot));
        }

        if (appConfig.RainBot != null)
        {
            subscribers.Add(new RainBotMonitor(appConfig.RainBot));
        }

        if (appConfig.SnowBot != null)
        {
            subscribers.Add(new SnowBotMonitor(appConfig.SnowBot));
        }

        return subscribers;
    }
}