using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;

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

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("log.txt"
            , retainedFileCountLimit : 30
            , rollingInterval: RollingInterval.Day)
            .CreateLogger();

        

        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Debug);
            builder.AddConsole();
            builder.AddDebug();
            builder.AddSerilog();
            //builder.AddEventLog();
            //builder.AddAzureLogging();
            //builder.SerialLog();
            //builder.AddClientLogging();
        });

        ILogger logger = loggerFactory.CreateLogger<Program>();

        try{

        logger.LogDebug("Application is starting up");
        logger.LogDebug("Debug level log");

        logger.LogInformation("Waiting for user input...");
        string userInput = Console.ReadLine();

        int favNumber = int.Parse(userInput);

        logger.LogInformation("User input: {UserInput}", userInput);
        logger.LogInformation("Application is shutting down");

        }
        catch(Exception ex){
            Console.WriteLine(ex.Message);
            logger.LogCritical(ex,ex.Message);
        }
       
    }
}