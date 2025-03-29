using System;
using Microsoft.EntityFrameworkCore;

namespace LibMan.Web.Db;

public class BookDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    //Allows the DbContext to be injected into the controller
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
}
