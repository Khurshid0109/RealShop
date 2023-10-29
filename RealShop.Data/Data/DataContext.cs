using RealShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RealShop.Data.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {  
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Category> Categories { get; set; }
}