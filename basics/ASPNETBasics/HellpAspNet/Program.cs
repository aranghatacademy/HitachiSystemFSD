var builder = WebApplication.CreateBuilder(args);
//All the services are registered here
builder.Services.AddControllers();
builder.Services.AddMvc(); //This is the default MVC service
                         //Only needed if you are using MVC and not the api's

var app = builder.Build();

//All the middleware are registered here

app.UseRouting();
app.MapControllers();

//This is the entry point of the application
//Public static void Main(string[] args)
app.Run();
