using Microsoft.EntityFrameworkCore;
using product.Models;

namespace product.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Product> Booth { get; set; }

    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configure default schema
        modelBuilder.HasDefaultSchema("product");

        modelBuilder.Entity<Booth>()
            .Property(b => b.Id)
            .IsRequired();
        
        modelBuilder.Entity<Product>(productEntityBuilder =>
            {
                productEntityBuilder.Property(p => p.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .IsRequired();

                productEntityBuilder.Property(p => p.Title)
                    .HasColumnName("Title")
                    .HasColumnType("text")
                    .IsRequired();

                productEntityBuilder.Property(p => p.Description)
                    .HasColumnName("Description")
                    .HasColumnType("text")
                    .IsRequired();
            }
        );
        
        base.OnModelCreating(modelBuilder);
    }
    #endregion
}