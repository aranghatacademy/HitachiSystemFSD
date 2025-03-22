namespace EventsInCSharp;

using System.ComponentModel;
using System.Timers;

public class TemperatureSensor 
{

    public event EventHandler<ExtremeTempDetectedEventArgs> ExtremeTempDetected;

    public TemperatureSensor()
    {
       Timer timer = new Timer(1000);
       timer.Elapsed += OnTimerElapsed;
       timer.Start();
    }

    public void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        var temp = new Random().Next(0, 110);
        if(temp > 80)
        {
            ExtremeTempDetected?.Invoke(this, new ExtremeTempDetectedEventArgs
                                { Message = "Extreme temperature detected"
                                , Temperature = temp
                                , Timestamp = DateTime.Now });
        }
    }
   
}

public class ExtremeTempDetectedEventArgs : EventArgs
{
    public double Temperature { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }

}
