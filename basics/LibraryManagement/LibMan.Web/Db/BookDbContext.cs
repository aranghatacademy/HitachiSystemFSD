using System;
using Microsoft.EntityFrameworkCore;

namespace LibMan.Web.Db;

public class BookDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<Member> Members { get; set; }

    //Allows the DbContext to be injected into the controller
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
}
