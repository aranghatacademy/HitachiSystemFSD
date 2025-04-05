using System;

namespace SampleApp.Model;

public class State
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Department> Departments { get; set; }

}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}
