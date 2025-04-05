using System;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using OrderDashboard.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OrderDashboard.Services;

public class OrderRecievingService : BackgroundService
{
    private readonly ILogger<OrderRecievingService> _logger;
    private readonly IHubContext<OrderMessageHub> _hubContext;

    public OrderRecievingService(ILogger<OrderRecievingService> logger, IHubContext<OrderMessageHub> hubContext)
    {
        _logger = logger;
        _hubContext = hubContext;
    }

    
   
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    _logger.LogInformation("Order receiving service is starting.");

    var factory = new ConnectionFactory { HostName = "localhost" };
    var connection = await factory.CreateConnectionAsync();
    var channel = await connection.CreateChannelAsync();

    await channel.QueueDeclareAsync("messageQueue", durable: true, exclusive: false, autoDelete: false, arguments: null);

    var consumer = new AsyncEventingBasicConsumer(channel);

    consumer.ReceivedAsync += async (model, ea) =>
    {
        try
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            _logger.LogInformation("Received message: {Message}", message);

            // Send message to SignalR hub
            await _hubContext.Clients.All.SendAsync("NewOrder", message);

            // Manually acknowledge after processing (recommended)
            await channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing message");
            // Optionally Nack the message if processing fails
            await channel.BasicNackAsync(ea.DeliveryTag, multiple: false, requeue: true);
        }
    };

    await channel.BasicConsumeAsync("messageQueue", autoAck: false, consumer: consumer);

    // Keep the connection/channel alive
    try
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
    finally
    {
        await channel.CloseAsync();
        await connection.CloseAsync();
    }
}


}
