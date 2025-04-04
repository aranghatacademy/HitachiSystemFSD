using Microsoft.Extensions.Logging;

namespace SampleLib;

public class ParcelnumberValidator
{
    public readonly ILogger<ParcelnumberValidator> _logger;

    //Dependency on ILogger<ParcelnumberValidator> is injected through the constructor
    public ParcelnumberValidator(ILogger<ParcelnumberValidator> logger)
    {
        _logger = logger;
    }

    //This method is used to validate the parcel number
    public bool IsValid(string parcelnumber)
    {
         _logger.LogInformation("Validating parcel number: {Parcelnumber}", parcelnumber);
         var isValid = parcelnumber.StartsWith("BLR",StringComparison.OrdinalIgnoreCase) && parcelnumber.Length == 5;

         _logger.LogInformation("Parcel number is valid: {IsValid}", isValid);
         return isValid;
    }
}
