using CollectionAndLinq;

public class Program
{
    public static void Main(string[] args)
    {
       // List<Employee> employees = new List<Employee>();


        /*SortedSet<Employee> employees = new SortedSet<Employee>();
        var emp1 = new Employee { Id = 1, Name = "Sree" }; //Diffrent hashcode
        var emp2 = new Employee { Id = 2, Name = "Ramesh" };
        var emp4 = new Employee { Id = 3, Name = "Jhon" }; //Diffrent hashcode
        var emp3 = new Employee { Id = 4, Name = "Babu" }; //Diffrent hashcode

        employees.Add(emp4);
        employees.Add(emp1);
        employees.Add(emp3);
        employees.Add(emp2);*/
       

        /*if(employees.Contains(emp3))
        {
            Console.WriteLine("Employee is in the list");
        }
        else
        {
            Console.WriteLine("Employee is not in the list");
        }
           
        foreach(var employee in employees)
        {
            Console.WriteLine($"Employee ID: {employee.Id}, Employee Name: {employee.Name}");
        } */
       

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
        
        /*Dictionary<string, string> stateAndCapitals = new Dictionary<string, string>();
        stateAndCapitals.Add("Karnataka", "Bangalore");
        stateAndCapitals.Add("Tamil Nadu", "Chennai");
        stateAndCapitals.Add("Maharashtra", "Mumbai");

        //Access a value based on key
        var capital = stateAndCapitals["Karnataka"];
        Console.WriteLine($"Capital of Karnataka is {capital}");

        if(stateAndCapitals.ContainsKey("Karnataka"))
        {
            Console.WriteLine("Karnataka is in the dictionary");
        }
        else
        {
            Console.WriteLine("Karnataka is not in the dictionary");
        }*/

        Dictionary<Employee, List<DateTime>> employeeAndLeaves = new Dictionary<Employee, List<DateTime>>();
       
        var emp1 = new Employee { Id = 1, Name = "Sree" }; //Diffrent hashcode
        var emp2 = new Employee { Id = 2, Name = "Ramesh" };
        var emp4 = new Employee { Id = 3, Name = "Jhon" }; //Diffrent hashcode
        var emp3 = new Employee { Id = 4, Name = "Babu" }; //Diffrent hashcode
        var emp5 = new Employee { Id = 1, Name = "Sree" }; //Same hashcode

        employeeAndLeaves.Add(emp1, new List<DateTime> { new DateTime(2024, 1, 1), new DateTime(2024, 1, 2) });
        employeeAndLeaves.Add(emp2, new List<DateTime> { new DateTime(2024, 1, 1), new DateTime(2024, 1, 2) });

        if(employeeAndLeaves.ContainsKey(emp5))
        {
            Console.WriteLine("Employee has taken leaves");
        }
        else
        {
            Console.WriteLine("Employee has not taken leaves");
        }
        

        //Access a value based on key
        foreach(KeyValuePair<Employee, List<DateTime>> employee in employeeAndLeaves)
        {
            Console.WriteLine($"Employee ID: {employee.Key.Id}, Employee Name: {employee.Key.Name}");
            foreach(var leave in employee.Value)
            {
                Console.WriteLine($"Leave Date: {leave}");
            }
        }
        
    }
}