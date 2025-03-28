using System;

namespace InterfacesBasics;

public class VodafoneSMSService : ISMSService
{
    public void SendSMS(string message, string phoneNumber)
    {
        Console.WriteLine($"Vodafone SMS sent to {phoneNumber}: {message}");
    }
}
