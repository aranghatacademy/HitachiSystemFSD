using HelloEfCore.EmployeeData;
using HelloEfCore.Entities;
using Microsoft.EntityFrameworkCore;

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

/*var employee = dbContext.Employees.Find(1);
var leaveRequest = new LeaveRequest
{
    //We are giving the employee to which the leave request is applied
    Employee = employee,
    StartDate = DateTime.UtcNow,
    EndDate = DateTime.UtcNow.AddDays(10),
    Reason = "Vacation",
    Status = LeaveStatus.Rejected
};

dbContext.LeaveRequests.Add(leaveRequest);
dbContext.SaveChanges();

Console.WriteLine("Leave request added successfully");*/

//select * from LeaveRequests where Status = 'Pending'

//Eager loading is used to load the related data from the database
///*var pendingLeaveRequests = dbContext.LeaveRequests.Include(l => l.Employee)
                                     //             .Where(l => l.Status == LeaveStatus.Pending).ToList();

/*foreach (var leaveRequest in pendingLeaveRequests)
{
    Console.WriteLine($"Leave request: {leaveRequest.Id} - {leaveRequest.Employee.Name} - {leaveRequest.StartDate.ToShortDateString()} - {leaveRequest.EndDate.ToShortDateString()} - {leaveRequest.Reason} - {leaveRequest.Status}");
}*/

//dbContext.Database.ExecuteSqlRaw("EXEC sp_GetPendingLeaveRequests",1,2,3);
/*dbContext.Database.ExecuteSqlRaw(@"update 
LeaveRequests 
set Status = 2 
where Id = 1");*/

/*var employee = new Employee
{
    Name = "John Doe",
    Email = "john.doe@example.com",
    Phone = "1234567890",
    Salary = 50000,
};*/

//dbContext.Employees.Add(employee);
//dbContext.SaveChanges();

/*var employee = dbContext.Employees.Find(1); // Get the emplyee from DB 4:40
Console.WriteLine("Enter emplyee salary");
var salary = Console.ReadLine();
employee.Salary = decimal.Parse(salary);
dbContext.SaveChanges(); // IF the rowversion is not same as the item retriveed in line 78, then it will throw an error

Console.WriteLine("Employee added successfully");

var emp1 = new Employee
{
    Name = "Janet",
    Email = "janet@example.com",
    Phone = "1234567890",
    Salary = 50000,
};

var emp2 = new Employee
{
    Name = "John2",
    Email = "john2@example.com",
    Phone = "1234567890",
    Salary = 50000,
};


dbContext.Employees.Add(emp1);
dbContext.Employees.Add(emp2);
dbContext.SaveChanges();*/

//select * from Employees where deleteddate is null
var employees = dbContext.Employees.ToList();

//select * from Employees where email = 'jhon@example.com' and deleteddate is null
var emp = dbContext.Employees.FirstOrDefault(D => D.Email == "jhon@example.com");


foreach (var employee in employees)
{
    Console.WriteLine($"Employee: {employee.Name} - {employee.Email} - {employee.Phone} - {employee.Salary}");
}

if(dbContext.Employees.Any(d => d.Name == "John"))
{
    Console.WriteLine("Employee found");
}
else
{
    Console.WriteLine("Employee not found");
}
Console.WriteLine("Employee added successfully");


