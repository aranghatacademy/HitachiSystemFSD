public class Program {
    public static void Main(string[] args) {

        int a = 10;
        int b = 20;
        int c = a + b;
        Console.WriteLine(c);

        var savingsAccount = new RegularSavingsAccount();
        var salarySavingsAccount = new SalarySavingsAccount();
        var loanAccount = new LoanAccount();

        savingsAccount.Balance = 10000;
        salarySavingsAccount.Balance = 20000;
        loanAccount.Balance = 10000;

       
       var consolidatedAccount = (salarySavingsAccount + savingsAccount) + loanAccount;
       Console.WriteLine(consolidatedAccount.Balance);
    
       // Console.WriteLine(savingsAccount.Balance);
       // Console.WriteLine(loanAccount.Balance);

    }
}
