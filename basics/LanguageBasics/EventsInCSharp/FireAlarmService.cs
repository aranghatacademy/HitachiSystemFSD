using System;

namespace EventsInCSharp;

public class FireAlarmService
{
    public void OnExtremeTempDetected(object sender, ExtremeTempDetectedEventArgs e)
    {
        if(e.Temperature > 80)
        {
            Console.WriteLine("Elevate temmrateure detected " + e.Message);
        }
    }
}

public class NotifyFireDepartment
{
    public void OnExtremeTempDetected(object sender, ExtremeTempDetectedEventArgs e)
    {
        if(e.Temperature > 100)
        {
            Console.WriteLine("Notify fire department mostly its a fire: " + e.Message);
        }
        else
        {
            Console.WriteLine("The temperature is not high for fire so not notifying the fire department " + e.Message);
        }
    }
}