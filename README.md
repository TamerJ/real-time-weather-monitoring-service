<h1>Real-Time Weather Service</h1>

Design and implement a C# console application that simulates a real-time weather monitoring and reporting service. The system should be capable of receiving and processing raw weather data in multiple formats (JSON, XML, etc.) from various weather stations for different locations. The application should include different types of 'weather bots' each of which is configured to behave differently based on the weather updates it receives.

Supported Input Formats:

JSON Format:
```
{
  "Location": "City Name",
  "Temperature": 23.0,
  "Humidity": 85.0
}
```

<b>XML Format:</b>
```
<WeatherData>
  <Location>City Name</Location>
  <Temperature>23.0</Temperature>
  <Humidity>85.0</Humidity>
</WeatherData>
```

The system should allow for the addition of new data formats with minimal changes to the existing code, demonstrating the Open-Closed principle of SOLID design principles.

Different Bot Types:
RainBot: This bot gets activated when the humidity level exceeds a certain limit specified in its configuration. Upon activation, it performs a specific action which involves printing a pre-configured message.
SunBot: This bot gets activated when the temperature rises above a certain limit specified in its configuration. Upon activation, it performs a specific action which involves printing a pre-configured message.
SnowBot: This bot is activated when the temperature drops below a certain limit specified in its configuration. Upon activation, it performs a specific action which involves printing a pre-configured message.
Example on How to Interact with the Application:
User starts the application, the system prompts: Enter weather data:.

User enters data in JSON format: ```{"Location": "City Name", "Temperature": 32, "Humidity": 40} or XML format: <WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>```

The system responds by activating the bots according to the provided weather data and the bots' configurations. If SunBot is enabled and its temperature threshold is lower than the given temperature, the system may respond with:

SunBot activated!
SunBot: "Wow, it's a scorcher out there!"
Configuration Details:
All the bot's settings should be controlled via a configuration file, including whether it is enabled, the threshold that activates it,
```
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
In this example, the enabled property turns the bot on or off, the humidityThreshold or temperatureThreshold sets the limit that will activate the bot, and message is what the bot will output when it is activated.


<h2>Integration Diagram</h2>

![Screenshot_36](https://github.com/TamerJ/real-time-weather-monitoring-service/assets/17861953/4387c76b-e54a-453c-b976-22c340356171)

![Screenshot_35](https://github.com/TamerJ/real-time-weather-monitoring-service/assets/17861953/9f62fb6e-45f5-4bac-9d88-7b34f02ea32d)


<h2>Demonstrations: Run Screenshots</h2>

👇 In this example, Two bots were triggered as the incoming weather data met their conditions successfully. Utilizing JSON Format
![Screenshot_40](https://github.com/TamerJ/real-time-weather-monitoring-service/assets/17861953/cdebff67-8444-4dd7-be30-7f5c1bd9b7a5)


👇 In this example, it demonstrates that the data feed (user input) continues to arrive, and the bots update accordingly.
![Screenshot_41](https://github.com/TamerJ/real-time-weather-monitoring-service/assets/17861953/86a539b0-c6ca-450b-b409-d91d3e3caf99)

👇 In this example, it demonstrates that the XML Data Input
![Screenshot_42](https://github.com/TamerJ/real-time-weather-monitoring-service/assets/17861953/9bc784ee-244d-41b0-a787-7582ccaaddff)

👇 In this example, it demonstrates accepting both XML and JSON Data format
![image](https://github.com/TamerJ/real-time-weather-monitoring-service/assets/17861953/7e4f9622-ba5f-4deb-adbf-8e9fed38dd2e)


<h2>Future work</h2>
<ul>
  <li>Implement Logs</li>
 <li>Implement Unit Test</li>
</ul>
