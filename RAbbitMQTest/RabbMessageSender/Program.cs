using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        string message = "";

        do
        {
            Console.WriteLine("Enter a Product name or 'exit' to quit");
            message = Console.ReadLine();

            var product = new Product
            {
                Id = 1,
                Name = message,
                Price = 100
            };

            if (message != "exit")
            {
                await SendMessage(JsonSerializer.Serialize(product));
               Console.WriteLine("Message sent");
            }
        }
        while (message != "exit");
    }

    private static async Task SendMessage(string message)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = await factory.CreateConnectionAsync())
       {
         var messageChannel = await connection.CreateChannelAsync();
         await messageChannel.QueueDeclareAsync("messageQueue"
                                , durable: true // This means of the reciever is offline, the message will be saved in the queue
                                , exclusive: false
                                , autoDelete: false, arguments: null);

         await messageChannel.BasicPublishAsync(exchange: "",
                                                routingKey: "messageQueue",
                                                body: Encoding.UTF8.GetBytes(message));
       }
        
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
