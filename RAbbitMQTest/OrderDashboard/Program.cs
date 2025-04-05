using OrderDashboard.Messages;
using OrderDashboard.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddLogging();
builder.Services.AddHostedService<OrderRecievingService>();
builder.Services.AddSignalR();
var app = builder.Build();


app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<OrderMessageHub>("/orders");
app.Run();
