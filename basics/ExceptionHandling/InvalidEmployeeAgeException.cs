using System;

namespace ExceptionHandling;

public class InvalidEmployeeAgeException : Exception
{ 
    public InvalidEmployeeAgeException() : base()
    {

    }

    public InvalidEmployeeAgeException(string message) : base(message)
    {

    }

    public InvalidEmployeeAgeException(string message, Exception innerException) : base(message, innerException)
    {

    }

    public InvalidEmployeeAgeException(DateTime dateOfBirth) 
                : base($"Employee must be at least 18 years old. Currently employee is only {DateTime.Now.Year - dateOfBirth.Year} years old")
    {

    }
}
