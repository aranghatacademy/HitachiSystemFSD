using System;
using HelloEfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelloEfCore.EmployeeData;

public class EmployeeDbContext : DbContext
{
    // Define the DbSet for the Employee entity
    public DbSet<Employee> Employees { get; set; }

    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=localhost;Database=EmployeeDb;User=postgres;Password=@rt1234$$;TrustServerCertificate=True");
         optionsBuilder.UseNpgsql("Host=localhost;Database=EmployeeDb;Username=postgres;Password=@rt1234$$");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
                    .Property(e => e.LastModified)
                    //.IsConcurrencyToken();
                    .IsRowVersion();

        modelBuilder.Entity<Employee>()
                    .HasQueryFilter(e => e.DeletedDate == null);

        modelBuilder.Entity<LeaveRequest>()
                    .HasQueryFilter(e => e.DeletedDate == null);

        modelBuilder.Entity<LeaveRequest>()
                    .Property(e => e.Status)
                    .HasDefaultValue(LeaveStatus.Pending);


        modelBuilder.Entity<LeaveRequest>()
                    .Property(e => e.StartDate)
                    .HasDefaultValue(DateTime.Now);

        modelBuilder.Entity<Employee>()
                    .HasIndex(e => e.Email)
                    .IsUnique();
    }
}
