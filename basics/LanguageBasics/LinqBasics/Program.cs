using LinqBasics;

public class Program
{
    static List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John Smith", City = City.Bangalore, Salary = 75000m },
        new Employee { Id = 2, Name = "Mary Johnson", City = City.Chennai, Salary = 82000m },
        new Employee { Id = 3, Name = "Steve Williams", City = City.Mumbai, Salary = 95000m },
        new Employee { Id = 4, Name = "Sarah Davis", City = City.Delhi, Salary = 68000m },
        new Employee { Id = 5, Name = "Michael Brown", City = City.Bangalore, Salary = 110000m },
        new Employee { Id = 6, Name = "Jessica Wilson", City = City.Chennai, Salary = 72000m },
        new Employee { Id = 7, Name = "David Miller", City = City.Mumbai, Salary = 88000m },
        new Employee { Id = 8, Name = "Jennifer Garcia", City = City.Delhi, Salary = 79000m },
        new Employee { Id = 9, Name = "Robert Taylor", City = City.Bangalore, Salary = 92000m },
        new Employee { Id = 10, Name = "Lisa Anderson", City = City.Chennai, Salary = 85000m }
    };

    static List<Leaves> leaves = new List<Leaves>
    {
        new Leaves { Id = 1, Employee = employees[0], Date = new DateTime(2024, 1, 1) },
        new Leaves { Id = 2, Employee = employees[0], Date = new DateTime(2024, 1, 2) },
        new Leaves { Id = 3, Employee = employees[1], Date = new DateTime(2024, 1, 3) },
        new Leaves { Id = 4, Employee = employees[2], Date = new DateTime(2024, 1, 3) },
        new Leaves { Id = 5, Employee = employees[3], Date = new DateTime(2024, 1, 4) },
    };

    public static void Main(string[] args)
    {
       

        //select * from employees e
        // join leaves l on e.id = l.employeeid
        // where city = 'Bangalore' order by salary desc

        /* var employeesInBangalore = from e in employees
                                   join l in leaves on e.Id equals l.Employee.Id
                                   where e.City == City.Bangalore && e.Salary > 60000
                                   orderby e.Salary descending
                                   select new { e.Id, e.Name, e.Salary, l.Date};
                                   //select e; */

         

        var employeesInBangalore = employees.Join(leaves, e => e.Id, l => l.Employee.Id, (e, l) => new { e.Id, e.Name, e.Salary, e.City, l.Date})
                                            .Where(d => d.City == City.Bangalore && d.Salary > 60000)
                                            .OrderByDescending(d => d.Salary);

        /* foreach(var employee in employeesInBangalore)
        {
            Console.WriteLine($"Employee ID: {employee.Id}, Employee Name: {employee.Name}, Salary: {employee.Salary}");
        } */

        var cityGroup = employees.GroupBy(d => d.City);

        var totalEmployees = employees.Where(d => d.City == City.Bangalore).Count();
        var totalSalary = employees.Where(d => d.City == City.Bangalore).Sum(d => d.Salary);
        var averageSalary = employees.Where(d => d.City == City.Bangalore).Average(d => d.Salary);
        var minSalary = employees.Where(d => d.City == City.Bangalore).Min(d => d.Salary);
        var maxSalary = employees.Where(d => d.City == City.Bangalore).Max(d => d.Salary);

        foreach(var cityInfo in cityGroup)
        {
            Console.WriteLine($"City: {cityInfo.Key}");
            foreach(var employee in cityInfo)
            {
                Console.WriteLine($"\t\tEmployee ID: {employee.Id}, Employee Name: {employee.Name}, Salary: {employee.Salary}");
            }
        }
    }
}