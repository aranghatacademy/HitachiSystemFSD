using CollectionAndLinq;

public class Program
{
    public static void Main(string[] args)
    {
       // List<Employee> employees = new List<Employee>();
        SortedSet<Employee> employees = new SortedSet<Employee>();
        var emp1 = new Employee { Id = 1, Name = "Sree" }; //Diffrent hashcode
        var emp2 = new Employee { Id = 2, Name = "Ramesh" };
        var emp4 = new Employee { Id = 3, Name = "Jhon" }; //Diffrent hashcode
        var emp3 = new Employee { Id = 4, Name = "Babu" }; //Diffrent hashcode

        employees.Add(emp4);
        employees.Add(emp1);
        employees.Add(emp3);
        employees.Add(emp2);
       

        /*if(employees.Contains(emp3))
        {
            Console.WriteLine("Employee is in the list");
        }
        else
        {
            Console.WriteLine("Employee is not in the list");
        }
            */
        foreach(var employee in employees)
        {
            Console.WriteLine($"Employee ID: {employee.Id}, Employee Name: {employee.Name}");
        }
       

        /*names.Add("John");
        names.Add("Jane");
        names.Add("Jim");
        names.Add("Jill");

        foreach(var name in names)
        {
            Console.WriteLine(name);
        }

        //IEquatable<T>
        if(names.Contains("John"))
        {
            Console.WriteLine("John is in the list");
        }

        names.Remove("John");*/
        
        
        
    }
}