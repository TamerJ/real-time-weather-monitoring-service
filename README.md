# 🌦️ Real-Time Weather Monitoring Service

## 📌 Project Overview

This C# console application simulates a real-time weather monitoring and reporting system. It ingests weather data from various stations in multiple formats (JSON, XML), dynamically activates weather bots based on configurable thresholds, and demonstrates extensible architecture principles.

## 🌦️ Weather Bot Types

Each bot is activated based on weather thresholds defined in the configuration file:

* **RainBot**: Activates when humidity exceeds its threshold
* **SunBot**: Activates when temperature exceeds its threshold
* **SnowBot**: Activates when temperature drops below its threshold

### Sample Bot Configuration

```json
{
  "RainBot": {
    "enabled": true,
    "humidityThreshold": 70,
    "message": "It looks like it's about to pour down!"
  },
  "SunBot": {
    "enabled": true,
    "temperatureThreshold": 30,
    "message": "Wow, it's a scorcher out there!"
  },
  "SnowBot": {
    "enabled": false,
    "temperatureThreshold": 0,
    "message": "Brrr, it's getting chilly!"
  }
}
```

## 🚀 Features

* Supports multiple input formats: JSON, XML, (YAML-ready via parser extension)
* Modular bot architecture (RainBot, SunBot, SnowBot)
* Configuration-driven behavior and thresholds
* Plug-and-play format detection and parsing
* Extensible design following SOLID principles

## 🖼️ Demonstrations

* ⚡ App Started <br> ![App-Started.png](./assets/App-Started.png)
* ✅ JSON input handling <br> ![Json-triggered.png](./assets/Json-triggered.png)
* 🧾 XML input handling  <br> ![xml-parser.png](./assets/xml-parser.png)
* 🤖 Multi-bot activation based on input  <br> ![multi-bot-activated.png](./assets/multi-bot-activated.png)

## 🧪 Sample Interaction

**Input:**

```json
{ "Location": "San Jose", "Temperature": 32, "Humidity": 40 }
```

**Output:**

```
SunBot activated!
SunBot: "Wow, it's a scorcher out there!"
```

## 🛠️ How to Run

1. Clone the repository

2. Ensure `.NET 6.0+` is installed 
3. Make sure `appsettings.json` is copied to the output directory if newer:
```xml
<ItemGroup>
   <None Update="appsettings.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
   </None>
</ItemGroup>  
```
4. Run the application via CLI:

   ```bash
   dotnet run
   ```

5. Enter Weather Data
When prompted, enter weather data in **any supported format**:

   ```json
   { "Location": "Seattle", "Temperature": 32, "Humidity": 40 }
   ```

   or

   ```xml
   <WeatherData><Location>Seattle</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>
   ```

## 📊 Architecture Highlights

* `IFormatDetector` identifies input format
* `ParserFactory` returns appropriate parser
* `IDataParser` parses raw input into structured `WeatherData`
* Bots subscribe to updates and react based on configuration

## ✅ Testing Strategy

Unit tests cover:

* Format detection and parser selection
* Weather data parsing (JSON, XML)
* Bot activation logic based on thresholds
* Configuration loading and validation

Tools used:

* `xUnit` for test scaffolding
* `FluentAssertions` for expressive assertions
* `coverlet` for coverage tracking

Run tests via:

```bash
dotnet test
```

![App-Started.png](./assets/Unit-Test-Sample-Run.png)


## 🔮 Future Enhancements

* Add structured logging
* Support additional formats as needed (YAML, CSV)