using System;
using Microsoft.EntityFrameworkCore;
using SampleApp.Model;

namespace SampleApp.Db;

public class SampleDbContext : DbContext
{
      public DbSet<User> Users { get; set; }
      public DbSet<State> States { get; set; }

      public DbSet<Department> Departments { get; set; }

      public DbSet<UserRole> UserRoles { get; set; }

      public DbSet<RoleMenu> RoleMenus { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
            optionsBuilder.UseNpgsql("Host=localhost;Database=SampleApp2;Username=postgres;Password=@rt1234$$");
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            var testNumber = new Random().Next(1000, 9999); 
            modelBuilder.Entity<State>().HasKey(e => e.Id);
      }
}
