namespace SampleLib;

public static class ParcelnumberValidator
{
    public static bool IsValid(string parcelnumber)
    {
         var isValid = parcelnumber.StartsWith("BLR",StringComparison.OrdinalIgnoreCase) && parcelnumber.Length == 5;
         return isValid;
    }
}
