using RealShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RealShop.Data.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {  
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    public DbSet<Categories> Categories { get; set; }
}