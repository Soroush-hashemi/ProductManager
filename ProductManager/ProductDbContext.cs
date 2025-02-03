using Microsoft.EntityFrameworkCore;
using ProductManager.Models;

namespace ProductManager;
public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> dbContext) : base(dbContext)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}