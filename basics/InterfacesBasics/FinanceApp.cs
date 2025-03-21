using System;

namespace InterfacesBasics;

public interface ISMSService
{
    void SendSMS(string message, string phoneNumber);
}

public class AirtelSMSService : ISMSService
{
    public void SendSMS(string message, string phoneNumber)
    {
        //Send the SMS
        Console.WriteLine($"Airtel SMS sent to {phoneNumber}: {message}");
    }
}

public class ABCSMSService : ISMSService
{
    public void SendSMS(string message, string phoneNumber)
    {
        //Send the SMS
        Console.WriteLine($"ABC SMS sent to {phoneNumber}: {message}");
    }
}

public class AuthenticationModule
{
    private ISMSService _smsService;

    public AuthenticationModule(ISMSService smsService)
    {
        _smsService = smsService;
    }

    public void Login(string username, string password)
    {
        //var smsService = new ABCSMSService();
        //smsService.SendSMS("Login successful", "1234567890");
        _smsService.SendSMS("Login successful", "1234567890");
    }
}

public class FinanceModule
{
    public ISMSService _smsService;

    /*public FinanceModule(ISMSService smsService)
    {
        _smsService = smsService;
    }*/

    public void WithDraw(string username, decimal amount)
    {
        //Withdraw the amount
        //Send a SMS
        ///var smsService = new ABCSMSService();
        //smsService.SendSMS("Withdrawal successful", "1234567890");
        _smsService.SendSMS("Withdrawal successful", "1234567890");
    }
    
}
