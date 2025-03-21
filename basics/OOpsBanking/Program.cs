public class Program {
    public static void Main(string[] args) {

        var savingsAccount = new RegularSavingsAccount();
        savingsAccount.Balance = 10000;
        var salarySavingsAccount = new SalarySavingsAccount();

        //savingsAccount.Deposit(1000);

        savingsAccount.DisplayAccountDetails();
        salarySavingsAccount.DisplayAccountDetails();

        //savingsAccount.CalculateInterest(); //5.5%
        //salarySavingsAccount.CalculateInterest(); //4.5%
        var loanAccount = new LoanAccount();
        loanAccount.Balance = 10000;
        loanAccount.Deposit(1000);
        loanAccount.DisplayAccountDetails();
       // loanAccount.CalculateInterest(); //12.5%
    
       // Console.WriteLine(savingsAccount.Balance);
       // Console.WriteLine(loanAccount.Balance);

    }
}
