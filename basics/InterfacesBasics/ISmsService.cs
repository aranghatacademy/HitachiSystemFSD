namespace InterfacesBasics;

//We create a contract of methods that a class or service must implement
public interface ISmsService
{
    void SentSms(string message, string phoneNumber);
}

public interface IWatsappService
{
    void SendWatsappMessage(string message, string phoneNumber);
}

//Implement the interface
public class DefaultSmsService : ISmsService {

    public void SentSms(string message, string phoneNumber) {
        Console.WriteLine($"Default SMS Service - > Sending SMS to {phoneNumber}: {message}");
    }

}

public class GlobalNotificationService : ISmsService, IWatsappService
{
    public void SendWatsappMessage(string message, string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public void SentSms(string message, string phoneNumber)
    {
        Console.WriteLine($"Global Notification Service - > Sending SMS to {phoneNumber}: {message}");
    }
}
