using System;

namespace ExtentionMethods;

public static  class EmployeeMethodExtentions
{
    //Extention Methods
    //1. Must be static
    //2. First parameter must be preceded by the 'this' keyword
    public static int GetYearsOfService(this Employee employee)
    {
        var yearsOfExperience = DateTime.Now.Subtract(employee.DateOfJoining);
        return (int)yearsOfExperience.TotalDays / 365;
    }
}


public static class StringExtentions
{
    public static int CountNumberOfSpaces(this string str)
    {
        return str.Trim().Split(' ').Length;
    }
}


public static class FileInfoExtentions
{
    public static bool IsImage(this FileInfo file)
    {
        return file.Extension.ToLower() == ".jpg" 
                    || file.Extension.ToLower() == ".png" 
                    || file.Extension.ToLower() == ".gif" 
                    || file.Extension.ToLower() == ".jpeg";
    }
}