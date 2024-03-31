﻿using Microsoft.Extensions.Configuration;
using real_time_weather_monitoring_service.Helpers;
using real_time_weather_monitoring_service.Models;
using real_time_weather_monitoring_service.Services;

namespace real_time_weather_monitoring_service;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to weather monitoring service.");

        var configuration = ConfigurationInitializer.Initialize();
        var appConfig = ConfigurationInitializer.GetConfigValue(configuration);

        Console.WriteLine("Enter weather data:");
        var userInput = Console.ReadLine();

        var dataParserService = new DataParserService();
        dataParserService.Parse(userInput!);

        Console.ReadLine();
    }
}