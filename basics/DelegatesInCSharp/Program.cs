
 // delegate - type of method that its going point to
#region Delegate Senario 1
 /*
public delegate int Operation(int x, int y);
public delegate void DisplayMessage(string message);
public class Program{

    public static void Main(string[] args){
       
        Console.WriteLine("Enter two numbers:");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the operation:");
        string operation = Console.ReadLine();

        Operation op = GetOperation(operation);
        int result = op(num1, num2);
        Console.WriteLine("Result: " + result);
 
    }

    public static Operation GetOperation(string operation){
        switch(operation){
            case "add":
                return Add;
            case "subtract":
                return Subtract;
            case "multiply":
                return Multiply;
            case "divide":
                return Divide;
        }

        return null;
    }

    public static int Add(int x, int y){
        return x + y;
    }

    public static int Subtract(int x, int y){
        return x - y;
    }

    public static int Multiply(int x, int y){
        return x * y;
    }

    public static int Divide(int x, int y){
        return x / y;
    }
}*/
#endregion




#region Delegate Senario 2

public delegate void CallbackFile(string fileName);

public class Program{

    public static void Main(string[] args){
       CallbackFile callback = ShareFileThroughEmail;
       DownloadFile("meme1.jpeg", callback);
    }

    public static void DownloadFile(string fileName, CallbackFile callback){
        Console.WriteLine("Downloading file: " + fileName);
        Thread.Sleep(5000);
        callback(fileName);
    }

    public static void ShareFileInInstagram(string fileName){
        Console.WriteLine("Sharing file in Instagram: " + fileName);
    }

    public static void ShareFileThroughEmail(string fileName){
        Console.WriteLine("Sharing file through email: " + fileName);
    }

    public static void PlayFileViaMediaPlayer(string fileName){
        Console.WriteLine("Playing file via media player: " + fileName);
    }
}


#endregion
