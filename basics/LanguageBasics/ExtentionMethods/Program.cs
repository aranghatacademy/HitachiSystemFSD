using ExtentionMethods;

var employee = new Employee();
employee.Name = "John Doe";
employee.DateOfJoining = new DateTime(2020, 1, 1);

string message = "HEllo World";
message.CountNumberOfSpaces();

if(employee.Name.CountNumberOfSpaces() > 1)
{
    Console.WriteLine("The employee has more than one name".CountNumberOfSpaces());
}
else
{
    Console.WriteLine("The employee has only one name");
}

FileInfo info = new FileInfo("test.txt");
info.IsImage();


// var yearsOfExperience = DateTime.Now.Subtract(employee.DateOfJoining);
// var totalExperienced = (yearsOfExperience.TotalDays / 365);


Console.WriteLine("The employee is with us for {0} years",employee.GetYearsOfService());
