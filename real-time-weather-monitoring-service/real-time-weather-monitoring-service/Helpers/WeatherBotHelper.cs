using real_time_weather_monitoring_service.Models;

namespace real_time_weather_monitoring_service.Helpers;

public static class WeatherBotHelper
{
    /// <summary>
    /// Prints a formatted activation message for a bot.
    /// </summary>
    public static void PrintActivationMessage(WeatherBotConfig config)
    {
        if (config == null || string.IsNullOrWhiteSpace(config.Name))
        {
            PrintError("Bot configuration is missing or unnamed.");
            return;
        }

        SetConsoleColor(ConsoleColor.Green);
        Console.WriteLine($"{config.Name} activated!");
        Console.WriteLine(config.Message);
        ResetConsoleColor();
    }

    /// <summary>
    /// Prints an error message in red.
    /// </summary>
    public static void PrintError(string message)
    {
        SetConsoleColor(ConsoleColor.Red);
        Console.WriteLine($"Error: {message}");
        ResetConsoleColor();
    }

    /// <summary>
    /// Prints a success message in green.
    /// </summary>
    public static void PrintSuccess(string message)
    {
        SetConsoleColor(ConsoleColor.Green);
        Console.WriteLine(message);
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
}