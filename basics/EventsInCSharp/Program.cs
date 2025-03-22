using EventsInCSharp;

public class Program
{
    private static FireAlarmService _fireAlarmService = new FireAlarmService();
    private static NotifyFireDepartment _notifyFireDepartment = new NotifyFireDepartment();
    public static void Main(string[] args)
    {
        TemperatureSensor temperatureSensor = new TemperatureSensor();

        //When the event occurs, the fire alarm service will be notified
        temperatureSensor.ExtremeTempDetected += _fireAlarmService.OnExtremeTempDetected;
        temperatureSensor.ExtremeTempDetected += _notifyFireDepartment.OnExtremeTempDetected;
        //Add one more listner that will notify all employees to assemble at the assembly point


        Console.WriteLine("Press Enter to stop the temperature sensor");
        Console.ReadLine();
    }
}