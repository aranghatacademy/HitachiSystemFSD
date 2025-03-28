/*Console.WriteLine("Enter your favorite number");
string  favNumberStr = Console.ReadLine();*/

using ExceptionHandling;

try
{
    //int favNumber = int.Parse(favNumberStr);
    Console.WriteLine("Enter the name of the employee");
    string name = Console.ReadLine();
    Console.WriteLine("Enter the date of birth of the employee");
    DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
    
    Employee employee = new Employee(name, dateOfBirth);

    //To Do : I need to close connection to the database
}
catch(FormatException ex)
{
    Console.WriteLine("Invalid input. Please enter a valid number");
}
catch(OverflowException ex)
{
    Console.WriteLine("Number is too large or too small");
}
catch(InvalidEmployeeAgeException ex)
{
    Console.WriteLine(ex.Message);
}
//General Exception is always the last catch block
//General exceotion that is Exception is the base class for all exceptions and thus should be the last catch block
catch(Exception ex) //General Exception
{
    Console.WriteLine("An error occurred");
}
//Catch statement is used to handle exceptions that are thrown from unmanged code
/*catch
{
    Console.WriteLine("An error occurred");
}*/
//Finally block will execute whether the try block is successful or not 
finally
{
    //To Do : I need to close connection to the database
    Console.WriteLine("Finally block");
}

    