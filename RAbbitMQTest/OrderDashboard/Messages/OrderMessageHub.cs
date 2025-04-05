using System;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace OrderDashboard.Messages;

public class OrderMessageHub : Hub
{
    private readonly ILogger<OrderMessageHub> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public OrderMessageHub(ILogger<OrderMessageHub> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task SendMessage(string message)
    {
         var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        _logger.LogInformation("Sending message: {Message}", message);
        await Clients.User(userId).SendAsync("NewOrder", message);
    }
}
