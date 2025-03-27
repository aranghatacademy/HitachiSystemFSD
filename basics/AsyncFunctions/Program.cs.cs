namespace AsyncFunctions;

public class Program
{
    public static async Task Main(string[] args)
    {
        //Continue with is a method that will execute the next method after the first one is finished
        //Equivalent to .then in Js

         
         var coffee = await MakeCoffee();
         var breakfast = await MakeBreakfast();
        
        Console.WriteLine("Will do something else while waiting for the coffee and breakfast");
        HaveBreakfast(coffee, breakfast);

        Console.ReadLine();
    }

    //The methods returns as Task, which is a placeholder for the future result
    //Sending back a promist in Js
    public static async Task<string> MakeCoffee()
    {
        Console.WriteLine("Making coffee...");
        // Thread.Sleep(2000);
        await Task.Delay(2000);

        Console.WriteLine("Coffee made");
        return "Black Coffee";
    }
    
    public static async Task<string> MakeBreakfast()
    {
        Console.WriteLine("Making breakfast...");
        // Thread.Sleep(2000);
        await Task.Delay(2000);

        Console.WriteLine("Breakfast made");
        //return Task.FromResult("Scrambled Eggs and Toast");
        return "Scrambled Eggs and Toast";
    }

    public static void HaveBreakfast(string coffee, string breakfast)
    {
        Console.WriteLine($"Having {coffee} and {breakfast} for breakfast");
    }
    
    
}