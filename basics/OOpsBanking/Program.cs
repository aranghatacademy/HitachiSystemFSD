public class Program {
    public static void Main(string[] args) {

        var savingsAccount = new RegularSavingsAccount();
        var salarySavingsAccount = new SalarySavingsAccount();

        Console.WriteLine(savingsAccount.MonthlyMinimumBalance);
        Console.WriteLine(salarySavingsAccount.MonthlyMinimumBalance);
       

        var loanAccount = new LoanAccount();
  
    }
}
