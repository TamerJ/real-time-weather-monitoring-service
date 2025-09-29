using real_time_weather_monitoring_service.Parsers;

namespace real_time_weather_monitoring_service.Tests
{
    public class ParserTests
    {
        [Fact]
        public void JsonParser_ShouldParseValidWeatherData()
        {
            var parser = new JsonParser();
            var input = "{\"location\":\"SF\",\"temperature\":22,\"humidity\":60}";

            var result = parser.Parse(input);

            Assert.NotNull(result);
            Assert.Equal("SF", result.Location);
            Assert.Equal(22, result.Temperature);
            Assert.Equal(60, result.Humidity);
        }

        [Fact]
        public void XmlParser_ShouldParseValidWeatherData()
        {
            var parser = new XmlParser();
            var input = "<WeatherData><location>SF</location><temperature>18</temperature><humidity>55</humidity></WeatherData>";

            var result = parser.Parse(input);

            Assert.NotNull(result);
            Assert.Equal("SF", result.Location);
            Assert.Equal(18, result.Temperature);
            Assert.Equal(55, result.Humidity);
        }

        [Theory]
        [InlineData("")]
        [InlineData("invalid json")]
        [InlineData("<WeatherData><location>Missing closing tag")]
        public void Parsers_ShouldReturnNull_ForMalformedInput(string input)
        {
            var jsonParser = new JsonParser();
            var xmlParser = new XmlParser();

            Assert.Null(jsonParser.Parse(input));
            Assert.Null(xmlParser.Parse(input));
        }
    }
}