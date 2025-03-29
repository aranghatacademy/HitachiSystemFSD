using System;
using Microsoft.EntityFrameworkCore;

namespace LibMan.Web.Db;

public class BookDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=BooksDb;Username=postgres;Password=@rt1234$$");
    }
}
