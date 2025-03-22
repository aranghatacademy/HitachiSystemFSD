using System;

namespace ExceptionHandling;

public class Employee
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }

    public Employee(string name, DateTime dateOfBirth)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        if(DateTime.Now.Year - dateOfBirth.Year < 18)
        {
            throw new InvalidEmployeeAgeException(dateOfBirth);
        }
    }
    
    
}
