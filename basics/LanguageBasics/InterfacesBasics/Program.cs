

using InterfacesBasics;

public class Program
{
    public static void Main(string[] args)
    {
        var smsService = GetSmsService();
        var authenticationModule = new AuthenticationModule(smsService);
        authenticationModule.Login("John", "123456");

        var financeModule = new FinanceModule();
        financeModule._smsService = smsService;
        financeModule.WithDraw("John", 1000);
    }

    //Dummy Dependency Container 
    public static ISMSService GetSmsService()
    {
        ISMSService smsService = new VodafoneSMSService(); //new ABCSMSService(); //new AirtelSMSService();
        return smsService;
    }
}

