using Microsoft.EntityFrameworkCore;
using product.Models;

namespace product.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
}