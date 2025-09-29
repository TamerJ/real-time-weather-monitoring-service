using real_time_weather_monitoring_service.Enums;
using real_time_weather_monitoring_service.FormatDetection;

namespace WeatherMonitor.Tests
{
    public class FormatDetectionTests
    {
        [Fact]
        public void JsonFormatDetector_ShouldDetectValidJson()
        {
            var detector = new JsonFormatDetector();
            var input = "{\"location\":\"San Jose\",\"temperature\":22}";

            Assert.True(detector.CanHandle(input));
            Assert.Equal(ParserType.Json, detector.Type);
        }

        [Fact]
        public void JsonFormatDetector_ShouldRejectXml()
        {
            var detector = new JsonFormatDetector();
            var input = "<weather><location>San Jose</location></weather>";

            Assert.False(detector.CanHandle(input));
        }

        [Fact]
        public void XmlFormatDetector_ShouldDetectValidXml()
        {
            var detector = new XmlFormatDetector();
            var input = "<weather><location>San Jose</location></weather>";

            Assert.True(detector.CanHandle(input));
            Assert.Equal(ParserType.Xml, detector.Type);
        }

        [Fact]
        public void XmlFormatDetector_ShouldRejectJson()
        {
            var detector = new XmlFormatDetector();
            var input = "{\"location\":\"San Jose\"}";

            Assert.False(detector.CanHandle(input));
        }

        [Theory]
        [InlineData("")]
        [InlineData("Just some random text")]
        [InlineData("location: San Jose")]
        public void Detectors_ShouldRejectUnknownFormats(string input)
        {
            var jsonDetector = new JsonFormatDetector();
            var xmlDetector = new XmlFormatDetector();

            Assert.False(jsonDetector.CanHandle(input));
            Assert.False(xmlDetector.CanHandle(input));
        }
    }
}