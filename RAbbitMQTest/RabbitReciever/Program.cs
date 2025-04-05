using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class Program
{
    public static async Task Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = await factory.CreateConnectionAsync())
       {
         var messageChannel = await connection.CreateChannelAsync();
         await messageChannel.QueueDeclareAsync("messageQueue"
                                , durable: true // This means of the reciever is offline, the message will be saved in the queue
                                , exclusive: false
                                , autoDelete: false, arguments: null);

         var consumer = new AsyncEventingBasicConsumer(messageChannel);
         consumer.ReceivedAsync += async (model, ea) =>
         {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Received message: {0}", message);
            await Task.CompletedTask;
         };

         await messageChannel.BasicConsumeAsync("messageQueue", autoAck: true, consumer: consumer);
         Console.ReadLine();
         Console.WriteLine("Waiting for messages. To exit press CTRL+C");
         await Task.CompletedTask;
       }
        
    }
}

