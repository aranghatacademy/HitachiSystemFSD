using LibMan.Web;
using LibMan.Web.Db;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/auth/login";
        options.AccessDeniedPath = "/auth/login";
    });

builder.Services.AddAuthorization();

//Provide the sms service
//Only one instance of the service will be created accross all users and all requests
builder.Services.AddSingleton<ISmsService, AirtelSmsService>();

//Only one instance of the service will be created for each request per user
///builder.Services.AddScoped<ISmsService, VodafoneSmsService>();

//A new instance of the service will be created for each request and each service
//builder.Services.AddTransient<ISmsService, VodafoneSmsService>();

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
app.UseLogUserRequest();
app.UseCalculatRequestTime();
//app.UseMiddleware<LogUserRequestMiddleware>();
//app.UseMiddleware<CalculatRequestTimeMiddleware>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
