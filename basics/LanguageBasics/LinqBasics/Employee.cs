namespace LinqBasics;

public enum City
{
    Bangalore,
    Chennai,
    Mumbai,
    Delhi
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public City City { get; set; }
    public decimal Salary { get; set; }
}


public class Leaves
{
    public int Id { get; set; }
    public Employee Employee { get; set; }
    public DateTime Date { get; set; }
}