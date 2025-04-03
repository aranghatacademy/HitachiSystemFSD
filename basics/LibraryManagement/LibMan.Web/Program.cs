using LibMan.Web;
using LibMan.Web.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Add the logging providers
builder.Services.AddLogging(log => 
        log.AddConsole()
        .AddDebug());

//Add the database context
builder.Services.AddDbContext<BookDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add the users database context
//builder.Services.AddDbContext<UserDbContext>(options =>
 //   options.UseNpgsql(builder.Configuration.GetConnectionString("UsersDbConnection")));

var app = builder.Build();

app.UseStaticFiles();
app.UseMiddleware<LogUserRequestMiddleware>();
app.UseMiddleware<CalculatRequestTimeMiddleware>();
app.UseRouting();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
