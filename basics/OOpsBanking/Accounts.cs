public abstract class Account {
    public int AccountNumber { get; set; }
    public Customer AccountHolder { get; set; }

    public double InterestRate { get; protected set; }
    public double Balance { get; set; }

    //1. Scenario1 : The function is COMMON for all child classes
    public double CalculateInterest() {
        return Balance * InterestRate / 100;
    }

    //2. Scenario2 : The function is DIFFERENT for all child classes
    //1. Abstract methoed will not have a body
    //2. Child classes must implement the method
    public abstract void Deposit(double amount);

    //3. Scenario3 : The function is COMMON for some child classes and DIFFERENT for others
    public virtual void DisplayAccountDetails() {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Balance: {Balance}");
        Console.WriteLine($"Interest Rate: {InterestRate}");
    }

    public static Account operator +(Account a, Account b) {
        a.Balance += b.Balance;
        return a;
    }   
}

//Savings account inherits from Account
public abstract class SavingsAccount : Account {
    
    //1. Child classes must be able to set the minimum balance
    //2. Outside world must not be able to set the minimum balance
    //3. Outside world must be able to read the minimum balance
    public double MonthlyMinimumBalance { get; protected set; }

    public override void Deposit(double amount)
    {
        Balance += amount;
    }
}

public class RegularSavingsAccount : SavingsAccount {

    public RegularSavingsAccount() {
        MonthlyMinimumBalance = 10000;
        InterestRate = 5.5f;
    }

    override public void DisplayAccountDetails() {
        base.DisplayAccountDetails();
        Console.WriteLine($"Monthly Minimum Balance: {MonthlyMinimumBalance}");
    }
}

sealed public class SalarySavingsAccount : SavingsAccount {

    public SalarySavingsAccount() {
        MonthlyMinimumBalance = 0;
        InterestRate = 4.5f;
    }
}


sealed public class LoanAccount : Account {
  
    public LoanAccount() {
        InterestRate = 12.5f;
    }

    override public void Deposit(double amount) {
        Balance -= amount;
    }

    public static LoanAccount operator +(LoanAccount a, LoanAccount b) {
        a.Balance -= b.Balance;
        return a;
    }
}
