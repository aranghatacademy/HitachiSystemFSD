using Microsoft.Extensions.Logging;

public class Program
{
    public static void Main(string[] args)
    {

        //Log Levels
        //Debug 
        //Information
        //Warning
        //Error
        //Critical

        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Debug);
            builder.AddConsole();
            builder.AddDebug();
            //builder.AddEventLog();
            //builder.AddAzureLogging();
            //builder.SerialLog();
            //builder.AddClientLogging();
        });

        ILogger logger = loggerFactory.CreateLogger<Program>();

        logger.LogDebug("Application is starting up");
        logger.LogDebug("Debug level log");

        logger.LogInformation("Waiting for user input...");
        string userInput = Console.ReadLine();

        logger.LogInformation("User input: {UserInput}", userInput);
        logger.LogInformation("Application is shutting down");
        
        
    }
}