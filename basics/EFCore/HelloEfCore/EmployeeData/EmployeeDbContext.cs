using System;
using HelloEfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelloEfCore.EmployeeData;

public class EmployeeDbContext : DbContext
{
    // Define the DbSet for the Employee entity
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=EmployeeDb;Username=postgres;Password=@rt1234$$");
    }
}
