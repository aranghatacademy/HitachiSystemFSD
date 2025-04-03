namespace LibMan.Web;

public interface ISmsService
{
    void SendSMS(string message, string phoneNumber);
}
