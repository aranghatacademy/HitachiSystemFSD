
delegate string GetUserNameDelegate();
public class Program
{

    public static void Main(string[] args)
    {
        //Pointing the delete to a anonymous method
        //Print print = (message) => Console.WriteLine(message);
        //Action<Input>
        //Func<Input1, Input2, Output>
        /*Action<string> print = (message) => Console.WriteLine(message);
        Func<string, string> getUserName = (message) => { Console.WriteLine(message); 
                                                          return Console.ReadLine();
                                                        };

        var userName = getUserName("Enter your name: ");
        print += (message) => File.WriteAllText("message.txt", userName);

        print("Hello, World!");*/

        // Create dynamilly in runtime
        List<Action<string>> errorHandlers = new List<Action<string>>();
        errorHandlers.Add((exception) => Console.WriteLine(exception));
        errorHandlers.Add((exception) => File.WriteAllText("error.txt", exception));

        HandleApplicationError(errorHandlers,new Exception("Application error"));
    }

    public static void HandleApplicationError(List<Action<string>> errorHandlers,Exception ex)
    {
        foreach(var errorHandler in errorHandlers)
        {
            errorHandler(ex.Message);
        }
    }

    /*
        static void PrintToConsole(string message)
        {
            Console.WriteLine(message);
        }
    

    static string GetUserName()
    {
        string userName = Console.ReadLine();
        return userName;
    }*/
}