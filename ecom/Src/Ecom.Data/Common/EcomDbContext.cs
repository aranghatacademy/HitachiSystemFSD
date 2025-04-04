using Ecom.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Data;

public class EcomDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Stock> Stocks { get; set; }

    public DbSet<Order> Orders { get; set; }

    public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options)
    {
    }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=ecom;Username=postgres;Password=@rt1234$$");
    }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

       
            
    }
}

