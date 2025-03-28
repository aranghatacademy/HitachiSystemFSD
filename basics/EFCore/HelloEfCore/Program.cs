using HelloEfCore.EmployeeData;
using HelloEfCore.Entities;

var dbContext = new EmployeeDbContext();

var employee = new Employee
{
    Name = "John Doe",
    Email = "john.doe@example.com",
    Phone = "1234567890"
};

dbContext.Employees.Add(employee);
dbContext.SaveChanges();

Console.WriteLine("Employee added successfully");
