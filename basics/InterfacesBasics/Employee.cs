
public abstract class Employee
{
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }

    public decimal GetSalary()
    {
        return Salary;
    }

    public void ApplyForLeave(int days)
    {
        Console.WriteLine($"Employee {Name} is applying for {days} days leave");
    }
}

public interface IApprovalManager
{
    void ApproveLeave(int days);
    void RejectLeave(int days);
}

public interface IRecruiter{
    void Recruit(string name, string email, decimal salary);
    void Terminate(string name, string email);
}

public class JSE : Employee
{
   
}

public class Manager : Employee,IApprovalManager
{
    public decimal ProjectBonus { get; set; }

    public void ApproveLeave(int days)
    {
        Console.WriteLine($"Manager {Name} is approving {days} days leave");
    }

    public void RejectLeave(int days)
    {
        Console.WriteLine($"Manager {Name} is rejecting {days} days leave");
    }
    
}

public class HRManager : Employee,IApprovalManager,IRecruiter
{
    public void ApproveLeave(int days)
    {
        Console.WriteLine($"HRManager {Name} is approving {days} days leave");
    }

    public void Recruit(string name, string email, decimal salary)
    {
        throw new NotImplementedException();
    }

    public void RejectLeave(int days)
    {
        Console.WriteLine($"HRManager {Name} is rejecting {days} days leave");
    }

    public void Terminate(string name, string email)
    {
        throw new NotImplementedException();
    }
}


