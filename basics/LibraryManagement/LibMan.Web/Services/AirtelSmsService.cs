namespace LibMan.Web;

public class AirtelSmsService : ISmsService
{
    private readonly ILogger<AirtelSmsService> _logger;
    public AirtelSmsService(ILogger<AirtelSmsService> logger)
    {
        _logger = logger;
    }
    public void SendSMS(string message, string phoneNumber)
    {
        _logger.LogInformation($"Airtel SMS sent to {phoneNumber}: {message}");
    }
}


public class VodafoneSmsService : ISmsService
{
    private readonly ILogger<VodafoneSmsService> _logger;
    public VodafoneSmsService(ILogger<VodafoneSmsService> logger)
    {
        _logger = logger;
    }
    public void SendSMS(string message, string phoneNumber)
    {
        _logger.LogInformation($"Vodafone SMS sent to {phoneNumber}: {message}");
    }
}
