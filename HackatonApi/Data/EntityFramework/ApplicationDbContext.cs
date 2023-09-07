using HackatonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Data.EntityFramework;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } 

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}