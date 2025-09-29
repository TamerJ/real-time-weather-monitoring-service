using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Publishers;
using real_time_weather_monitoring_service.Subscribers;

namespace WeatherMonitor.Tests
{
    public class BotTests
    {
        [Fact]
        public void WeatherStationPublisher_ShouldNotifySubscribedBots()
        {
            // Arrange
            var publisher = new WeatherStationPublisher();
            var bot1 = new TestBot();
            var bot2 = new TestBot();

            publisher.Subscribe(bot1);
            publisher.Subscribe(bot2);

            var data = new WeatherData
            {
                Location = "SF",
                Temperature = 22,
                Humidity = 60
            };

            // Act
            publisher.State = data;
            publisher.Notify();

            // Assert
            Assert.Equal(data, bot1.LastReceivedData);
            Assert.Equal(data, bot2.LastReceivedData);
        }

        [Fact]
        public void WeatherStationPublisher_ShouldNotNotifyUnsubscribedBots()
        {
            // Arrange
            var publisher = new WeatherStationPublisher();
            var bot1 = new TestBot();
            var bot2 = new TestBot();

            publisher.Subscribe(bot1);
            // bot2 is not subscribed

            var data = new WeatherData
            {
                Location = "San Jose",
                Temperature = 18,
                Humidity = 55
            };

            // Act
            publisher.State = data;
            publisher.Notify();

            // Assert
            Assert.Equal(data, bot1.LastReceivedData);
            Assert.Null(bot2.LastReceivedData);
        }

        private class TestBot : IWeatherBot
        {
            public WeatherData? LastReceivedData { get; private set; }

            public void Evaluate(WeatherData data)
            {
                LastReceivedData = data;
            }
        }
    }
}