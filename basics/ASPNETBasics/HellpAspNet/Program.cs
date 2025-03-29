var builder = WebApplication.CreateBuilder(args);
//All the services are registered here
builder.Services.AddControllersWithViews();


var app = builder.Build();

//All the middleware are registered here

app.UseRouting();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//This is the entry point of the application
//Public static void Main(string[] args)
app.Run();
