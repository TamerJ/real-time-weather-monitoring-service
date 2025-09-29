using System.Xml.Serialization;

namespace real_time_weather_monitoring_service.Models;

[XmlRoot("weatherdata")]
public class WeatherData
{
    [XmlElement("location")]
    public string Location { get; set; }

    [XmlElement("temperature")]
    public float Temperature { get; set; }

    [XmlElement("humidity")]
    public float Humidity { get; set; }
}