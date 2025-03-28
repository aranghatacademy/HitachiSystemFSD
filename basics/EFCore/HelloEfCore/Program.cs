using HelloEfCore.EmployeeData;
using HelloEfCore.Entities;

var dbContext = new EmployeeDbContext();

/*var employee = new Employee
{
    Name = "John Doe",
    Email = "john.doe@example.com",
    Phone = "1234567890"
};

dbContext.Employees.Add(employee);
dbContext.SaveChanges();*/

/*foreach (var employee in dbContext.Employees)
{
    Console.WriteLine($"Employee: {employee.Name} - {employee.Email} - {employee.Phone} - {employee.Note} - {employee.Salary}");
}

var totalEmployees = dbContext.Employees.Count();
Console.WriteLine($"Total employees: {totalEmployees}");


//Update the data of employee with id 1
var e = dbContext.Employees.Find(1);
e.Salary = 100000;
e.Note = "Salaary details updated";
dbContext.SaveChanges();

Console.WriteLine("Employee added successfully");*/

var employee = dbContext.Employees.Find(1);
var leaveRequest = new LeaveRequest
{
    //We are giving the employee to which the leave request is applied
    Employee = employee,
    StartDate = DateTime.UtcNow,
    EndDate = DateTime.UtcNow.AddDays(10),
    Reason = "Vacation",
    Status = LeaveStatus.Pending
};

dbContext.LeaveRequests.Add(leaveRequest);
dbContext.SaveChanges();

Console.WriteLine("Leave request added successfully");
