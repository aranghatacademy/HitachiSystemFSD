using System.Text;
using Ecom.Data;
using Ecom.Data.REpositories.Products;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMvc();

builder.Services.AddLogging();
builder.Services.AddHttpContextAccessor();

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


//builder.Services.AddDbContext<EcomDbContext>(options =>
   // options.UseNpgsql(builder.Environment.));


builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
