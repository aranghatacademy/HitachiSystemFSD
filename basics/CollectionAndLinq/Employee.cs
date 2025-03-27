using System;

namespace CollectionAndLinq;

public class Employee : IEquatable<Employee>, IComparable<Employee>, IComparer<Employee>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public bool Equals(Employee other)
    {
        return Id == other.Id;
    }

    // > 0 then current object is greater than other
    // < 0 then current object is less than other
    // = 0 then current object is equal to other
    public int CompareTo(Employee other)
    {
        return Name.CompareTo(other.Name);
    }

    public int Compare(Employee? x, Employee? y)
    {
        return x.Id.CompareTo(y.Id);
    }
}
