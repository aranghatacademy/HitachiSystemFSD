namespace EventsInCSharp;

using System.ComponentModel;
using System.Timers;

public class TemperatureSensor 
{

    public event EventHandler<ExtremeTempDetectedEventArgs> ExtremeTempDetected;
    List<ExtremeTempDetectedEventArgs> _temperatureHistory = new List<ExtremeTempDetectedEventArgs>();

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
            _temperatureHistory.Add(new ExtremeTempDetectedEventArgs{ Message = "Extreme temperature detected"  
                                    , Temperature = temp
                                    , Timestamp = DateTime.Now });
            //IF the template sensor has detected a temperature above 80 for 3 minutes, then notify the fire department
           // if(_temperatureHistory.Count > 5 && _temperatureHistory.Last().Timestamp > DateTime.Now.AddMinutes(-3))
            //{
                 ExtremeTempDetected?.Invoke(this, new ExtremeTempDetectedEventArgs
                                        { Message = "Extreme temperature detected"
                                        , Temperature = temp
                                        , Timestamp = DateTime.Now });
                _temperatureHistory.Clear();
            //}
        }
    }
   
}

public class ExtremeTempDetectedEventArgs : EventArgs
{
    public double Temperature { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }

}
