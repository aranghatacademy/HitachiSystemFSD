public abstract class Account {
    public int AccountNumber { get; set; }
    public Customer AccountHolder { get; set; }
    public double Balance { get; set; }
}

//Savings account inherits from Account
public abstract class SavingsAccount : Account {
    
    //1. Child classes must be able to set the minimum balance
    //2. Outside world must not be able to set the minimum balance
    //3. Outside world must be able to read the minimum balance
    public double MonthlyMinimumBalance { get; protected set; }
}

public class RegularSavingsAccount : SavingsAccount {

    public RegularSavingsAccount() {
        MonthlyMinimumBalance = 10000;
    }
}

sealed public class SalarySavingsAccount : SavingsAccount {

    public SalarySavingsAccount() {
        MonthlyMinimumBalance = 0;
    }
}


sealed public class LoanAccount : Account {
  
    
}
