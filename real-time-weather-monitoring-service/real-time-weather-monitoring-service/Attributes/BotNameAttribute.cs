namespace real_time_weather_monitoring_service.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class BotNameAttribute : Attribute
{
    public string Name { get; }

    public BotNameAttribute(string name)
    {
        Name = name;
    }
}
