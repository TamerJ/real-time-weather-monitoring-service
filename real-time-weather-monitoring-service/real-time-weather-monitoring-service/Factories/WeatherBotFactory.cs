using System.Reflection;
using real_time_weather_monitoring_service.Attributes;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Subscribers;

namespace real_time_weather_monitoring_service.Factories;

public static class WeatherBotFactory
{
    private static readonly Dictionary<string, Type> BotTypes = DiscoverBotTypes();

    private static Dictionary<string, Type> DiscoverBotTypes()
    {
        var botTypes = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        var allTypes = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in allTypes)
        {
            if (!typeof(IWeatherBot).IsAssignableFrom(type) || type.IsAbstract) continue;

            var attr = type.GetCustomAttribute<BotNameAttribute>();
            if (attr != null)
            {
                botTypes[attr.Name] = type;
            }
        }

        return botTypes;
    }

    public static IWeatherBot Create(string botName, WeatherBotConfig config)
    {
        if (!BotTypes.TryGetValue(botName, out var type))
            throw new InvalidOperationException($"Unknown bot type: {botName}");

        return (IWeatherBot)Activator.CreateInstance(type, config)!;
    }

    public static IEnumerable<string> GetAvailableBotNames() => BotTypes.Keys;
}