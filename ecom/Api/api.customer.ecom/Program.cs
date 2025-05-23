using System.Text;
using Ecom.Data;
using Ecom.Data.REpositories.Customers;
using Ecom.Data.REpositories.Products;
using Ecom.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddLogging();
//builder.Services.AddMemoryCache();
builder.Services.AddDistributedRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "Ecom";
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))
        };
    });

builder.Services.AddAuthorization(options => options.AddPolicy(JwtBearerDefaults.AuthenticationScheme
        , policy => policy.RequireAuthenticatedUser()));


builder.Services.AddDbContext<EcomDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();


/*app.Use(async (context, next) =>
{
    if(!context.Request.Path.Value.StartsWith("https:"))
    {
        context.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("HTTPS is required"));
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        return;
    }
    await next();
});*/

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
