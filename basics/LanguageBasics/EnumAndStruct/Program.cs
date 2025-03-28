enum ShirtSize
{
    S,
    M,
    L,
    XL,
    XXL,
    XXXL
}


struct CartItem
{
    public string Name;
    public int Quantity;
    public decimal Price;
    public ShirtSize Size; 

    /// <summary>
    /// Encapsulates the display method for the CartItem struct.
    /// </summary>
    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Quantity: {Quantity}, Price: {Price}, Size: {Size} \n\n. TOTAL PRICE: {Price * Quantity}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        /*Console.WriteLine("Enter your shirt size:\n Choose from the following options: \n ");
        string[] sizes = Enum.GetNames<ShirtSize>();
        foreach(string s in sizes)
            Console.WriteLine(s);

        string input = Console.ReadLine();

       if(Enum.TryParse(input, out ShirtSize size))
            Console.WriteLine("Your shirt size is: " + size);
        else
            Console.WriteLine("Invalid shirt size");*/

        var cartIteam1 = new CartItem
        {
            Name = "Shirt",
            Quantity = 1,
            Price = 100,
            Size = ShirtSize.L
        };

        var cartIteam2 = new CartItem
        {
            Name = "Running Shirt",
            Quantity = 2,
            Price = 50,
            Size = ShirtSize.S
        };

        cartIteam1.Display();
        cartIteam2.Display();
    }
}

